using ApplicationModels.Account;
using ApplicationModels.Transaction;

namespace Application.Abstractions.Repositories;

public interface IAccountRepository
{
    public Task<Account?> FindAccountByUserIdAsync(long accountId);
    Task<Account?> CreateAccountAsync(string accountName, string pin, long balance);
    Task<long> GetBalanceAsync(long accountId);
    Task<long> DepositAsync(long accountId, long amount);
    Task<long> WithdrawAsync(long accountId, long amount);

    Task<List<Account>> GetAllAccountsAsync();

    Task<IEnumerable<Transaction>> GetTransactionHistoryAsync(long accountId);
}