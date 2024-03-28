using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ILocationConsumeApiService _locationConsumeApiService;
        private readonly IDataProtector _dataProtector;
        private readonly IReservationConsumeApiService _reservationConsumeApiService;
        public ReservationController(ILocationConsumeApiService locationConsumeApiService, IDataProtectionProvider dataProtector, IReservationConsumeApiService reservationConsumeApiService)
        {
            _locationConsumeApiService = locationConsumeApiService;
            _dataProtector = dataProtector.CreateProtector("RentACarController");
            _reservationConsumeApiService = reservationConsumeApiService;
        }


        public async Task GetLocationSelect()
        {
            var values = await _locationConsumeApiService.GetListAsync("Locations");
            ViewBag.PickUpSelectList = new SelectList(values, "LocationId", "Name");
            ViewBag.DropOffSelectList = new SelectList(values, "LocationId", "Name");
        }

        public async Task<IActionResult> Index(string CarId, string CarModel, string CarBrand)
        {
            ViewBag.CarId = int.Parse(_dataProtector.Unprotect(CarId));
            ViewBag.CarModel = CarModel;
            ViewBag.CarBrand = CarBrand;
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";

            await GetLocationSelect();
            return View(new CreateReservationDto());
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var result = await _reservationConsumeApiService.CreateAsync("Reservations", createReservationDto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
