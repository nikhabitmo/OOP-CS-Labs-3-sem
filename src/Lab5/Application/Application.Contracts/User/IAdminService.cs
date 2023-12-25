namespace Application.Contracts.User;

public interface IAdminService
{
    public Task<List<ApplicationModels.Account.Account>> GetAllAccounts();

    // public void ChangeSystemPassword(string currentSystemPassword, string newSystemPassword);
}