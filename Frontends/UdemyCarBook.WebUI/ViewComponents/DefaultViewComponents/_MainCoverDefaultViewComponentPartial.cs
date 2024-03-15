using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _MainCoverDefaultViewComponentPartial : ViewComponent
    {
        private readonly IBannerConsumeApiService _bannerConsumeService;

        public _MainCoverDefaultViewComponentPartial(IBannerConsumeApiService bannerConsumeService)
        {
            _bannerConsumeService = bannerConsumeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _bannerConsumeService.GetListAsync("Banners"));
        }
    }
}
