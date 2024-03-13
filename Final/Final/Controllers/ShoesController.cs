using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class ShoesController : Controller
    {
        private readonly IShoesRepository repo;

        public ShoesController(IShoesRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var shoes = repo.GetAllShoes();
            return View(shoes);
        }
        public IActionResult ViewShoes(int id)
        {
            var pair = repo.GetShoesById(id);
            return View(pair);
        }
        public IActionResult UpdateShoes(int id)
        {
            Shoes shoes = repo.GetShoesById(id);
            if (shoes == null)
            {
                return View("ProductNotFound");
            }
            return View(shoes);
        }
        public IActionResult UpdateShoesToDatabase(Shoes shoes)
        {
            repo.UpdateShoes(shoes);

            return RedirectToAction("ViewShoes", new { id = shoes.idShoes });
        }
        public IActionResult InsertPair()
        { return View("InsertPair"); }
        public IActionResult InsertShoesToDatabase(Shoes shoes)
        {
            repo.InsertPair(shoes);
            return RedirectToAction("Index");
        }
        public IActionResult DeletePair(int idShoes)
        {
            repo.DeletePair(idShoes);
            return RedirectToAction("Index");
        }
    }
}