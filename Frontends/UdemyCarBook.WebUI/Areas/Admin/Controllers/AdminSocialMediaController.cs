using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminSocialMediaController : Controller
    {
        private readonly ISocialMediaConsumeApiService _SocialMediaConsumeApiSocialMedia;
        private readonly IDataProtector _dataProtect;
        public AdminSocialMediaController(ISocialMediaConsumeApiService SocialMediaConsumeApiSocialMedia, IDataProtectionProvider dataProtect)
        {
            _SocialMediaConsumeApiSocialMedia = SocialMediaConsumeApiSocialMedia;
            _dataProtect = dataProtect.CreateProtector("AdminSocialMediaController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _SocialMediaConsumeApiSocialMedia.GetListAsync("SocialMedias");
            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.SocialMediaId.ToString()));
            return View(values);
        }
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var response = await _SocialMediaConsumeApiSocialMedia.CreateAsync("SocialMedias", createSocialMediaDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            return View(await _SocialMediaConsumeApiSocialMedia.GetByIdUpdateAsync("SocialMedias", dataValue));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var response = await _SocialMediaConsumeApiSocialMedia.UpdateAsync("SocialMedias", updateSocialMediaDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _SocialMediaConsumeApiSocialMedia.RemoveAsync("SocialMedias", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
