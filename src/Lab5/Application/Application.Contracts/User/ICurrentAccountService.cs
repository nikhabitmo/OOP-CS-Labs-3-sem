namespace Application.Contracts.User;

public interface ICurrentAccountService
{
    ApplicationModels.Account.Account? Account { get; }
}