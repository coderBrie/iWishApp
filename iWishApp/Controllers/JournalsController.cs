using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using iWishApp.Data;
using iWishApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iWishApp.Controllers
{
    public class JournalsController : Controller
    {
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private ApplicationDbContext _context;

       
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
        public JournalsController(ApplicationDbContext context)
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
}

