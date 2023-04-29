using Microsoft.AspNetCore.Mvc;

namespace iWishApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Identity/Account/Login")]
        public IActionResult Add() 
        { 
            return View();
        }
    }
}
