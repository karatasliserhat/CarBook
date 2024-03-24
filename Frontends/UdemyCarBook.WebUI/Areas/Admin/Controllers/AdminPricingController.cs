using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AdminPricingController : Controller
    {
        private readonly IPricingConsumeApiService _PricingConsumeApiService;
        private readonly IDataProtector _dataProtect;
        public AdminPricingController(IPricingConsumeApiService PricingConsumeApiService, IDataProtectionProvider dataProtect)
        {
            _PricingConsumeApiService = PricingConsumeApiService;
            _dataProtect = dataProtect.CreateProtector("AdminPricingController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _PricingConsumeApiService.GetListAsync("Pricings");
            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.PricingId.ToString()));
            return View(values);
        }

        public IActionResult CreatePricing()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
        {
            var response = await _PricingConsumeApiService.CreateAsync("Pricings", createPricingDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            return View(await _PricingConsumeApiService.GetByIdUpdateAsync("Pricings", dataValue));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePricingDto updatePricingDto)
        {
            var response = await _PricingConsumeApiService.UpdateAsync("Pricings", updatePricingDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _PricingConsumeApiService.RemoveAsync("Pricings", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
