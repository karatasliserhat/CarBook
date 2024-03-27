using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarController : Controller
    {
        private readonly IRentACarConsumeApiService _rentaCarConsumeApiService;

        public RentACarController(IRentACarConsumeApiService rentaCarConsumeApiService)
        {
            _rentaCarConsumeApiService = rentaCarConsumeApiService;
        }

        public async Task<IActionResult> Index()
        {
            var locationData = JsonSerializer.Deserialize<ResultRentAcarLocationFilterDto>(TempData["Result"].ToString());
            var response = await _rentaCarConsumeApiService.GetRentACarFilter(locationData.LocationId, true);
            return View(response);
        }
    }
}
