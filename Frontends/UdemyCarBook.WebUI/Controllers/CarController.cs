using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarPricingConsumeApiServe _carService;

        public CarController(ICarPricingConsumeApiServe carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";
            return View(await _carService.GetListAsync("CarPricings", "CarPricingWithCarsDayList"));
        }
    }
}
