using System.Security;
using Application.Abstractions.Repositories;
using Application.Account;
using Application.Contracts.User;
using Application.Contracts.Users;

namespace Application.Users;

public class UserService : IUserService
{
    private readonly IAccountRepository _repository;
    private CurrentAccountManager _currentAccountManager;

    public UserService(IAccountRepository repository, CurrentAccountManager currentAccountManager)
    {
        _repository = repository;
        _currentAccountManager = currentAccountManager;
    }

    public async Task<LoginResult> LoginAsBasicUser(long id, string pin)
    {
        _currentAccountManager.Account = await _repository.FindAccountByUserIdAsync(id);

        if (_currentAccountManager.Account is null)
        {
            return new LoginResult.NotFound();
        }

        if (string.Equals(_currentAccountManager.Account.Pin, pin, StringComparison.Ordinal))
        {
            return new LoginResult.SuccessAsUser();
        }

        return new LoginResult.Failure();
    }

    public async Task<LoginResult> LoginAsAdmin(long id, string password)
    {
        _currentAccountManager.Account = await _repository.FindAccountByUserIdAsync(id);

        if (_currentAccountManager.Account == null)
        {
            return new LoginResult.NotFound();
        }

        if (id != 1)
        {
            return new LoginResult.Failure();
        }

        if (string.Equals(password, Config.SystemData.SystemPassword, StringComparison.Ordinal))
        {
            return new LoginResult.SuccessAsAdmin();
        }

        throw new SecurityException("The incorrect input password");
    }

    public async Task<ApplicationModels.Account.Account?> FindAccountByUserId(long id)
    {
        return await _repository.FindAccountByUserIdAsync(id);
    }
}