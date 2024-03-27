using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ILocationConsumeApiService _locationConsumeApiService;

        public DefaultController( ILocationConsumeApiService locationConsumeApiService)
        {
            _locationConsumeApiService = locationConsumeApiService;
        }

        public async Task GetLocationListSelect()
        {
            var values = await _locationConsumeApiService.GetListAsync("Locations");

            ViewBag.SelectValues = new SelectList(values, "LocationId", "Name");
        }

        public async Task<IActionResult> Index()
        {
            await GetLocationListSelect();
            return View(new ResultRentAcarLocationFilterDto());
        }
        [HttpPost]
        public IActionResult Index(ResultRentAcarLocationFilterDto resultRentAcarLocationFilter)
        {

            TempData["Result"] = JsonSerializer.Serialize(resultRentAcarLocationFilter);
            return RedirectToAction("Index", "RentACar");

        }
    }
}
