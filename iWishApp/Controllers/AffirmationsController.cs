using iWishApp.Models;
using iWishApp.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iWishApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace iWishApp.Controllers
{
    public class AffirmationsController : Controller



    {

        private ApplicationDbContext _context;
        public AffirmationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // start index //
        // view all affifrmation below//

        public IActionResult Index(string SearchString)
        {
            ViewBag.CurrentFilter = SearchString;
            var affirmations = from a in _context.Affirmations
                               select a;
           


            if (!String.IsNullOrEmpty(SearchString))
            {
                affirmations = affirmations.Where(a => a.Text.Contains(SearchString));
            }

            {
                return View(affirmations.ToList());

            }
            
        }


        //[Authorize]
        [HttpGet]
        public IActionResult Add()
        {//put a n empty add affirmations view model

            AddAffirmationsViewModel addAffirmationsViewModel = new AddAffirmationsViewModel();
            return View(addAffirmationsViewModel);
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Add(AddAffirmationsViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                Affirmations affirmation = new Affirmations(viewModel.Text);
                _context.Affirmations.Add(affirmation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        //[Authorize]
        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.affirmations = _context.Affirmations.ToList();

            return View();
        }

       
       //[Authorize]
       [HttpPost]
        public IActionResult Delete(int[] affirmationIds)
        {
            foreach (int affirmationid in affirmationIds)
            {
                Affirmations affirmation = _context.Affirmations.Find(affirmationid);

                if (affirmation != null)
                {
                    _context.Affirmations.Remove(affirmation);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }


}