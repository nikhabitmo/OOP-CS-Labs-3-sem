using Application.Account;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class CreateAccountController : Controller
{
    private AccountService _accountService;

    public CreateAccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    public IActionResult Index()
    {
        return View("~/Views/Home/CreateAccount.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> Create(string userName, string pin)
    {
        ApplicationModels.Account.Account? accountCreated = await _accountService.CreateAccountAsync(userName, pin, 0);
        TempData["AccountCreatedMessage"] = $"Account successfully created! . Your ID is {accountCreated?.Id}, please remember it";
        return Index();
    }
}