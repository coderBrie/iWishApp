using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using iWishApp.Models;
using iWishApp.Data;
using iWishApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace iWishApp.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _context;

    //public HomeController(ILogger<HomeController> logger)

    //{
    //    _logger = logger;
    //}
    private static string userAffirmation = "";
    public IActionResult Index()
    {
        // Retrieve the user's affirmation from session or storage
        ViewBag.UserAffirmation = userAffirmation;
        return View();

       
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }



    [HttpPost]
    public IActionResult AddAffirmation(string affirmationText)
    {
        userAffirmation = affirmationText;
        return RedirectToAction("Index");
    }
}






