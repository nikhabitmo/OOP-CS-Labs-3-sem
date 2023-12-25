using Application.Users;
using ApplicationModels.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers;

public class DashboardAdminController : Controller
{
    private readonly AdminService _adminService;

    public DashboardAdminController(AdminService adminService)
    {
        _adminService = adminService;
    }

    public IActionResult Index()
    {
        return View("~/Views/Home/DashboardAdmin.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> GetAllAccounts()
    {
        List<Account> accounts = await _adminService.GetAllAccounts();
        TempData["Accounts"] = JsonConvert.SerializeObject(accounts);
        return Index();
    }

    [HttpPost]
    public IActionResult ChangeSystemPassword(string currentSystemPassword, string newSystemPassword)
    {
        _adminService.ChangeSystemPassword(currentSystemPassword, newSystemPassword);
        return Index();
    }
}