using System.Security.Claims;
using Application.Account;
using Application.Contracts.User;
using Application.Contracts.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class LoginController : Controller
{
    private IUserService _userService;
    private CurrentAccountManager _currentAccountManager;

    public LoginController(IUserService userService, CurrentAccountManager currentAccountManager)
    {
        _userService = userService;
        _currentAccountManager = currentAccountManager;
    }

    public IActionResult Index()
    {
        return View("~/Views/Home/Login.cshtml");
    }

    public IActionResult DashboardBasicUser()
    {
        return View("~/Views/Home/DashboardBasicUser.cshtml");
    }

    public IActionResult DashboardAdmin()
    {
        return View("~/Views/Home/DashboardAdmin.cshtml");
    }

    public async Task<IActionResult> Login(long id, string password)
    {
        LoginResult? result = await AuthorizationAdmin(id, password);
        if (result is LoginResult.SuccessAsAdmin)
        {
            HttpContext.Session.SetInt32("accountId", (int)id);
            _currentAccountManager.Account = await _userService.FindAccountByUserId(id);
            return DashboardAdmin();
        }

        result = await AuthorizationUser(id, password);
        if (result is LoginResult.SuccessAsUser)
        {
            var claims = new List<Claim>
            {
#pragma warning disable CA1305
                new Claim(ClaimTypes.Name, id.ToString()),
#pragma warning restore CA1305
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            HttpContext.Session.SetInt32("accountId", (int)id);

            _currentAccountManager.Account = await _userService.FindAccountByUserId(id);
            return DashboardBasicUser();
        }

        ViewData["ErrorMessage"] = "Invalid username or password";
        return Index();
    }

    private async Task<LoginResult> AuthorizationAdmin(long id, string password)
    {
        return await _userService.LoginAsAdmin(id, password);
    }

    private async Task<LoginResult> AuthorizationUser(long id, string pin)
    {
        return await _userService.LoginAsBasicUser(id, pin);
    }
}