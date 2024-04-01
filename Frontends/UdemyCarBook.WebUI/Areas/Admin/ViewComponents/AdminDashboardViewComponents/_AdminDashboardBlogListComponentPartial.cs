using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.ViewComponents.AdminDashboardViewComponents
{
    public class _AdminDashboardBlogListComponentPartial : ViewComponent
    {
        private readonly IBlogConsumeApiService _blogConsumeApiService;

        public _AdminDashboardBlogListComponentPartial(IBlogConsumeApiService blogConsumeApiService)
        {
            _blogConsumeApiService = blogConsumeApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _blogConsumeApiService.GetBlogWithAuthorAndCategoryListAsync());
        }
    }
}
