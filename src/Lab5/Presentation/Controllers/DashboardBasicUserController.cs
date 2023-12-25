using Application.Account;
using ApplicationModels.Transaction;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers;

public class DashboardBasicUserController : Controller
{
    private readonly AccountService _accountService;
    private readonly CurrentAccountManager _currentAccountManager;

    public DashboardBasicUserController(AccountService accountService, CurrentAccountManager currentAccountManager)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        _currentAccountManager =
            currentAccountManager ?? throw new ArgumentNullException(nameof(currentAccountManager));
    }

    public IActionResult Index()
    {
        return View("~/Views/Home/DashboardBasicUser.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> Withdraw(long amount)
    {
        int? accountId = HttpContext.Session.GetInt32("accountId");
        Console.WriteLine(accountId);

        if (accountId != null)
            TempData["WithDraw"] = await _accountService.WithdrawAsync((long)accountId, amount);

        return Index();
    }

    [HttpPost]
    public async Task<IActionResult> Deposit(long amount)
    {
        int? accountId = HttpContext.Session.GetInt32("accountId");

        if (accountId != null)
        {
            TempData["Deposit"] = await _accountService.DepositAsync((long)accountId, amount);
        }

        return Index();
    }

    [HttpPost]
    public async Task<IActionResult> Balance()
    {
        int? accountId = HttpContext.Session.GetInt32("accountId");
        if (accountId != null)
        {
            TempData["Balance"] = await _accountService.GetBalanceAsync((long)accountId);
        }

        return Index();
    }

    [HttpPost]
    public async Task<IActionResult> Transactions()
    {
        int? accountId = HttpContext.Session.GetInt32("accountId");
        if (accountId != null)
        {
            IEnumerable<Transaction> transactions = await _accountService
                .GetTransactionHistoryAsync((long)accountId);
            TempData["Transactions"] = JsonConvert.SerializeObject(transactions);
        }

        return Index();
    }
}