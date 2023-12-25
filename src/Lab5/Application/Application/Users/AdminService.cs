using System.Security;
using Application.Abstractions.Repositories;
using Application.Contracts.User;

namespace Application.Users;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _repository;

    public AdminService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public virtual void ChangeSystemPassword(string currentSystemPassword, string newSystemPassword)
    {
        if (string.Equals(currentSystemPassword, Config.SystemData.SystemPassword, StringComparison.Ordinal))
        {
            Config.SystemData.SystemPassword = newSystemPassword;
            return;
        }

        throw new SecurityException("The incorrect system password input");
    }

    public async Task<List<ApplicationModels.Account.Account>> GetAllAccounts()
    {
        return await _repository.GetAllAccountsAsync();
    }
}