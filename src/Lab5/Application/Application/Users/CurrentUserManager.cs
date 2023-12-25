using Application.Contracts.User;
using ApplicationModels.Users;

namespace Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}