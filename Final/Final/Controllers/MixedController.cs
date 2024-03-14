using Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class MixedController : Controller
    {
        private readonly IShoesRepository _shoesRepository;
        private readonly IHatRepository _hatRepository;
        
        public MixedController(IHatRepository hatsRepository, IShoesRepository shoesRepository)
        {
            _hatRepository = hatsRepository;
            _shoesRepository = shoesRepository;
        }
        public IActionResult Index()
        {
            var hats = _hatRepository.GetAllHats();
            var shoes = _shoesRepository.GetAllShoes();

            var viewModel = new MixedView
            {
                Hats = hats,
                Shoes = shoes
            };

            return View(viewModel);
        }
    }
}
