using Application.Account;
using Application.Contracts.Account;
using Application.Contracts.User;
using Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<AdminService>();

        collection.AddScoped<UserService>();
        collection.AddScoped<AccountService>();
        return collection;
    }
}