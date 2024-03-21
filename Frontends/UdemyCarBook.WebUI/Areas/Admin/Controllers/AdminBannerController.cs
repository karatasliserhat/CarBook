using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]

    public class AdminBannerController : Controller
    {
        private readonly IBannerConsumeApiService _BannerConsumeApiService;
        private readonly IDataProtector _dataProtect;
        public AdminBannerController(IBannerConsumeApiService BannerConsumeApiService, IDataProtectionProvider dataProtect)
        {
            _BannerConsumeApiService = BannerConsumeApiService;
            _dataProtect = dataProtect.CreateProtector("AdminBannerController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _BannerConsumeApiService.GetListAsync("Banners");
            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.BannerId.ToString()));
            return View(values);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var response = await _BannerConsumeApiService.CreateAsync("Banners", createBannerDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            return View(await _BannerConsumeApiService.GetByIdUpdateAsync("Banners", dataValue));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            var response = await _BannerConsumeApiService.UpdateAsync("Banners", updateBannerDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _BannerConsumeApiService.RemoveAsync("Banners", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
