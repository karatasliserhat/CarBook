using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminAboutController : Controller
    {
        private readonly IAboutConsumeApiService _AboutConsumeApiService;
        private readonly IDataProtector _dataProtect;
        public AdminAboutController(IAboutConsumeApiService AboutConsumeApiService, IDataProtectionProvider dataProtect)
        {
            _AboutConsumeApiService = AboutConsumeApiService;
            _dataProtect = dataProtect.CreateProtector("AdminAboutController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _AboutConsumeApiService.GetListAsync("Abouts");
            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.AboutId.ToString()));
            return View(values);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var response = await _AboutConsumeApiService.CreateAsync("Abouts", createAboutDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            return View(await _AboutConsumeApiService.GetByIdUpdateAsync("Abouts", dataValue));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            var response = await _AboutConsumeApiService.UpdateAsync("Abouts", updateAboutDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _AboutConsumeApiService.RemoveAsync("Abouts", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
