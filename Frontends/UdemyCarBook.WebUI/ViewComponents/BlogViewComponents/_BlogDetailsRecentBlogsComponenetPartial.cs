using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsRecentBlogsComponenetPartial : ViewComponent
    {
        private readonly IBlogConsumeApiService _blogConsumeApiService;

        public _BlogDetailsRecentBlogsComponenetPartial(IBlogConsumeApiService blogConsumeApiService)
        {
            _blogConsumeApiService = blogConsumeApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _blogConsumeApiService.GetLastThreeBlogWithAuthorList());
        }
    }
}
