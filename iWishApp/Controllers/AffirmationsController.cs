using iWishApp.Models;
using iWishApp.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iWishApp.Data;

namespace iWishApp.Controllers
{
    public class AffirmationsController : Controller



    {

        private ApplicationDbContext _context;
        public AffirmationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Affirmations> affirmations = _context.Affirmations.ToList();
            return View(affirmations);
        }

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
                Affirmations affirmation = new Affirmations(viewModel.Name, viewModel.Category, viewModel.Text);
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