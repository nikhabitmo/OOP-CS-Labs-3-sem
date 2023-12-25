using System.Data;
using Application.Abstractions.Repositories;
using ApplicationModels.Account;
using ApplicationModels.Transaction;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

#pragma warning disable CA1725
    public async Task<Account?> FindAccountByUserIdAsync(long account_id)
#pragma warning restore CA1725
    {
        const string sql = @"
                       SELECT account_id, account_name, pin, balance
                       FROM accounts
                       WHERE account_id = @account_id;
                       ";

        NpgsqlConnection? connection = null;

        try
        {
            connection = await _connectionProvider.GetConnectionAsync(default);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.AddParameter("account_id", account_id);

                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync() is false)
                        return null;

                    long receivedAccountId = await reader.GetFieldValueAsync<long>(0);
                    string receivedUsername = await reader.GetFieldValueAsync<string>(1);
                    string receivedPin = await reader.GetFieldValueAsync<string>(2);
                    long receivedAmount = await reader.GetFieldValueAsync<long>(3);

                    return new Account(receivedAccountId, receivedUsername, receivedPin, receivedAmount);
                }
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error in FindUserByIdAsync: {ex.Message}");
            return null;
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }

    public async Task<Account?> CreateAccountAsync(string accountName, string pin, long balance)
    {
        const string sql = @"
                   INSERT INTO accounts (account_name, pin, balance) 
                   VALUES (@accountName, @pin, @balance)
                   RETURNING account_id, account_name, pin, balance;
                   ";

        NpgsqlConnection? connection = null;

        try
        {
            connection = await _connectionProvider.GetConnectionAsync(default);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@accountName", accountName);
                command.Parameters.AddWithValue("@pin", pin);
                command.Parameters.AddWithValue("@balance", balance);

                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync() is false)
                        throw new NpgsqlException();

                    long receivedAccountId = reader.GetInt64(0);
                    string receivedAccountName = reader.GetString(1);
                    string receivedPin = reader.GetString(2);
                    long receivedBalance = reader.GetInt64(3);

                    return new Account(receivedAccountId, receivedAccountName, receivedPin, receivedBalance);
                }
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error in CreateAccountAsync: {ex.Message}");
            return null;
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }

    public async Task<long> GetBalanceAsync(long accountId)
    {
        const string sql = @"
                       SELECT balance
                       FROM accounts
                       WHERE account_id = @accountId;
                       ";

        NpgsqlConnection? connection = null;

        try
        {
            connection = await _connectionProvider.GetConnectionAsync(default);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@accountId", accountId);

                object? result = await command.ExecuteScalarAsync();

#pragma warning disable CA1305
                return result != null ? Convert.ToInt64(result) : -1;
#pragma warning restore CA1305
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error in GetBalanceAsync: {ex.Message}");
            return -1;
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }

    public async Task<long> DepositAsync(long accountId, long amount)
    {
        const string depositSql = @"
                       UPDATE accounts
                       SET balance = balance + @amount
                       WHERE account_id = @accountId;
                       ";

        const string logTransactionSql = @"
                       INSERT INTO transactions (account_id, transaction_type, amount, date_time)
                       VALUES (@accountId, 'Deposit', @amount, @dateTime);
                       ";

        NpgsqlConnection? connection = null;

        try
        {
            connection = await _connectionProvider.GetConnectionAsync(default);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = new NpgsqlCommand(depositSql, connection))
            {
                command.Parameters.AddWithValue("@accountId", accountId);
                command.Parameters.AddWithValue("@amount", amount);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    using (var logCommand = new NpgsqlCommand(logTransactionSql, connection))
                    {
                        logCommand.Parameters.AddWithValue("@accountId", accountId);
                        logCommand.Parameters.AddWithValue("@amount", amount);
                        logCommand.Parameters.AddWithValue("@dateTime", DateTime.Now);

                        await logCommand.ExecuteNonQueryAsync();
                    }
                }

                return rowsAffected;
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error in DepositAsync: {ex.Message}");
            return -1;
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }

    public async Task<long> WithdrawAsync(long accountId, long amount)
    {
        const string withdrawSql = @"
                       UPDATE accounts
                       SET balance = balance - @amount
                       WHERE account_id = @accountId
                           AND balance >= @amount;
                       ";

        const string logTransactionSql = @"
                       INSERT INTO transactions (account_id, transaction_type, amount, date_time)
                       VALUES (@accountId, 'Withdrawal', @amount, @dateTime);
                       ";

        NpgsqlConnection? connection = null;

        try
        {
            connection = await _connectionProvider.GetConnectionAsync(default);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = new NpgsqlCommand(withdrawSql, connection))
            {
                command.Parameters.AddWithValue("@accountId", accountId);
                command.Parameters.AddWithValue("@amount", amount);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    using (var logCommand = new NpgsqlCommand(logTransactionSql, connection))
                    {
                        logCommand.Parameters.AddWithValue("@accountId", accountId);
                        logCommand.Parameters.AddWithValue("@amount", amount);
                        logCommand.Parameters.AddWithValue("@dateTime", DateTime.UtcNow);

                        await logCommand.ExecuteNonQueryAsync();
                    }
                }

                return rowsAffected;
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error in WithdrawAsync: {ex.Message}");
            return -1;
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }

    public async Task<List<Account>> GetAllAccountsAsync()
    {
        const string getAllAccountsSql = @"
                   SELECT account_id, account_name, pin, balance
                   FROM accounts;
                   ";

        NpgsqlConnection? connection = null;

        try
        {
            connection = await _connectionProvider.GetConnectionAsync(default);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = new NpgsqlCommand(getAllAccountsSql, connection))
            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
            {
                var accounts = new List<Account>();

                while (await reader.ReadAsync())
                {
                    long accountId = reader.GetInt64(0);
                    string accountName = reader.GetString(1);
                    string pin = reader.GetString(2);
                    long balance = reader.GetInt64(3);

                    accounts.Add(new Account(accountId, accountName, pin, balance));
                }

                return accounts;
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error in GetAllAccountsAsync: {ex.Message}");
            return new List<Account>();
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }

    public async Task<IEnumerable<Transaction>> GetTransactionHistoryAsync(long accountId)
    {
        const string sql = @"
                       SELECT transaction_id, account_id, transaction_type, amount, date_time
                       FROM transactions
                       WHERE account_id = @accountId
                       ORDER BY date_time DESC;
                       ";

        NpgsqlConnection? connection = null;

        try
        {
            connection = await _connectionProvider.GetConnectionAsync(default);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@accountId", accountId);

                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    var transactions = new List<Transaction>();

                    while (await reader.ReadAsync())
                    {
                        transactions.Add(new Transaction(
                            reader.GetInt64(0),
                            reader.GetInt64(1),
                            reader.GetString(2),
                            reader.GetInt64(3),
                            reader.GetDateTime(4)));
                    }

                    return transactions;
                }
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error in GetTransactionHistoryAsync: {ex.Message}");
            return Enumerable.Empty<Transaction>();
        }
        finally
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }
}