using Application.Abstractions.Repositories;
using Application.Contracts.Account;
using ApplicationModels.Transaction;

namespace Application.Account;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public Task<ApplicationModels.Account.Account?> CreateAccountAsync(string accountName, string pin, long balance)
    {
        return _repository.CreateAccountAsync(accountName, pin, balance);
    }

    public Task<long> GetBalanceAsync(long accountId)
    {
        return _repository.GetBalanceAsync(accountId);
    }

    public Task<long> DepositAsync(long accountId, long amount)
    {
        return _repository.DepositAsync(accountId, amount);
    }

    public Task<long> WithdrawAsync(long accountId, long amount)
    {
        return _repository.WithdrawAsync(accountId, amount);
    }

    public Task<IEnumerable<Transaction>> GetTransactionHistoryAsync(long accountId)
    {
        return _repository.GetTransactionHistoryAsync(accountId);
    }
}