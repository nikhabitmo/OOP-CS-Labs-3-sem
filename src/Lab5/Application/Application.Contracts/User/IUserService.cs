using Application.Contracts.Users;

namespace Application.Contracts.User;

public interface IUserService
{
    public Task<LoginResult> LoginAsBasicUser(long id, string pin);
    public Task<LoginResult> LoginAsAdmin(long id, string password);
    public Task<ApplicationModels.Account.Account?> FindAccountByUserId(long id);
}