using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class HatsController : Controller
    {
        private readonly IHatRepository repo;

        public HatsController(IHatRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var products = repo.GetAllHats();
            return View(products);
        }
        public IActionResult ViewHat(int id)
        {
            var hat = repo.GetHatsById(id);
            return View(hat);
        }
        public IActionResult UpdateHat(int id)
        {
            Hats hat = repo.GetHatsById(id);
            if (hat == null)
            {
                return View("ProductNotFound");
            }
            return View(hat);
        }   
        public IActionResult UpdateHatToDatabase(Hats hat)
        {
            repo.UpdateHats(hat);

            return RedirectToAction("ViewHat", new { id = hat.idHats });
        }
        public IActionResult InsertHat()
        { return View("InsertHat"); }
        public IActionResult InsertHatToDatabase(Hats hat)
        {
            repo.InsertHat(hat);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteHat(int idHats)
        {
            repo.DeleteHat(idHats);
            return RedirectToAction("Index");
        }
    }
}
