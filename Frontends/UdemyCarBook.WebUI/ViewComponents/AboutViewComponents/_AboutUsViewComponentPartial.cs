using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsViewComponentPartial : ViewComponent
    {
        private readonly IAboutConsumeApiService _aboutConsumeApiService;

        public _AboutUsViewComponentPartial(IAboutConsumeApiService aboutConsumeApiService)
        {
            _aboutConsumeApiService = aboutConsumeApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _aboutConsumeApiService.GetListAsync("Abouts"));
        }
    }
}
