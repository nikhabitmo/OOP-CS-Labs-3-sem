using ApplicationModels.Transaction;

namespace Application.Contracts.Account;

public interface IAccountService
{
    Task<ApplicationModels.Account.Account?> CreateAccountAsync(string accountName, string pin, long balance);
    Task<long> GetBalanceAsync(long accountId);
    Task<long> DepositAsync(long accountId, long amount);
    Task<long> WithdrawAsync(long accountId, long amount);
    Task<IEnumerable<Transaction>> GetTransactionHistoryAsync(long accountId);
}