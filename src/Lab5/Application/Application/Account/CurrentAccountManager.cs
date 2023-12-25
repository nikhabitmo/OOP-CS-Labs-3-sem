using Application.Contracts.User;

namespace Application.Account;

public class CurrentAccountManager : ICurrentAccountService
{
    public ApplicationModels.Account.Account? Account { get; set; }
}