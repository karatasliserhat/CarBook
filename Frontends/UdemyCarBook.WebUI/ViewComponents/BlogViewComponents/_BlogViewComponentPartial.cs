using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogViewComponentPartial:ViewComponent
    {
        private readonly IBlogConsumeApiService _blogConsumeApiService;

        public _BlogViewComponentPartial(IBlogConsumeApiService blogConsumeApiService)
        {
            _blogConsumeApiService = blogConsumeApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _blogConsumeApiService.GetListAsync("Blogs", "GetLastThreeBlogsWithAuthorsAndCategory"));
        }
    }
}
