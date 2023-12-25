namespace Application.Contracts.User;
public interface ICurrentUserService
{
    ApplicationModels.Users.User? User { get; }
}