using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly ICarPricingConsumeApiServe _carPricingConsumeApiServe;

        public CarPricingController(ICarPricingConsumeApiServe carPricingConsumeApiServe)
        {
            _carPricingConsumeApiServe = carPricingConsumeApiServe;
        }

        public  async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";

            return View(await _carPricingConsumeApiServe.GetCarPricingWithTimePeriod());
        }
       

    }
}
