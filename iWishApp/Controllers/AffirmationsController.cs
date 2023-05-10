using iWishApp.Models;
using iWishApp.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iWishApp.Data;
using Microsoft.AspNetCore.Authorization;
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
            //List<Affirmations> affirmations = _context.Affirmations.ToList();
            //add feature below//


            if (!String.IsNullOrEmpty(SearchString))
            {
                affirmations = affirmations.Where(a => a.Text.Contains(SearchString));
            }

            {
                return View(affirmations.ToList());

            }
            //return View(affirmations);
        }

        //[HttpPost]
        //public IActionResult Index(string SearchString)

        //{
        //    //List<Affirmations> affirmations = _context.Affirmations.ToList();


        //    ViewData["CurrentFilter"] = SearchString;
        //    var affirmations = from a in _context.Affirmations
        //                        select a;
        //    {
        //        //ViewData["CurrentFilter"] = SearchString;
        //        //var affirmations = from a in _context.Affirmations
        //        //                 select a;

        //        if (!String.IsNullOrEmpty(SearchString))
        //        {
        //            affirmations = affirmations.Where(a => a.Text.Contains(SearchString));
        //        }

        //        return View("Index", affirmations);

        //        //add feature below//
        //        //List<Affirmations> affirmations = _context.Affirmations.ToList();
        //        //return View(affirmations);
        //    }

        //}

        //[Authorize]
        [HttpGet]
        public IActionResult Add()
        {//put a n empty add affirmations view model

            AddAffirmationsViewModel addAffirmationsViewModel = new AddAffirmationsViewModel();
            return View(addAffirmationsViewModel);
        }



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

        public IActionResult Delete()
        {
            ViewBag.affirmations = _context.Affirmations.ToList();

            return View();
        }



        [HttpPost]
        public IActionResult Delete(int[] affirmationIds)
        {
            foreach (int affirmationId in affirmationIds)
            {
                Affirmations theAffirmation = _context.Affirmations.Find(affirmationId);
                _context.Affirmations.Remove(theAffirmation);
            }

            _context.SaveChanges();

            return Redirect("/Affirmations");
        }

        // POST: Affirmations/Delete
        //    [HttpPost]
        //    public IActionResult Delete(int[] affirmationIds)
        //    {
        //        foreach (int affirmationid in affirmationIds)
        //        {
        //            Affirmations affirmation = _context.Affirmations.Find(affirmationid);

        //            if (affirmation != null)
        //            {
        //                _context.Affirmations.Remove(affirmation);
        //            }
        //        }

        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
    }
}