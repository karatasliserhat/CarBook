using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AdminLocationController : Controller
    {
        private readonly ILocationConsumeApiService _LocationConsumeApiService;
        private readonly IDataProtector _dataProtect;
        public AdminLocationController(ILocationConsumeApiService LocationConsumeApiService, IDataProtectionProvider dataProtect)
        {
            _LocationConsumeApiService = LocationConsumeApiService;
            _dataProtect = dataProtect.CreateProtector("AdminLocationController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _LocationConsumeApiService.GetListAsync("Locations");
            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.LocationId.ToString()));
            return View(values);
        }

        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var response = await _LocationConsumeApiService.CreateAsync("Locations", createLocationDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            return View(await _LocationConsumeApiService.GetByIdUpdateAsync("Locations", dataValue));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateLocationDto updateLocationDto)
        {
            var response = await _LocationConsumeApiService.UpdateAsync("Locations", updateLocationDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _LocationConsumeApiService.RemoveAsync("Locations", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
