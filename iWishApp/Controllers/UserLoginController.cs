using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using iWishApp.Models;

namespace iWishApp.Controllers;

public class UserLoginController : Controller
{
    private readonly ILogger<UserLoginController> _logger;

    public UserLoginController(ILogger<UserLoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

