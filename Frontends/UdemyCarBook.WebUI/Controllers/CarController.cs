using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarConsumeApiService _carService;

        public CarController(ICarConsumeApiService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _carService.GetListAsync("Cars", "GetCarWithBrand"));
        }
    }
}
