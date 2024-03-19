using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentPartial : ViewComponent
    {
        private readonly ICategoryConsumeApiService _categoryConsumeApiService;

        public _BlogDetailsCategoryComponentPartial(ICategoryConsumeApiService categoryConsumeApiService)
        {
            _categoryConsumeApiService = categoryConsumeApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _categoryConsumeApiService.GetListAsync("Categories"));
        }
    }
}
