using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{

    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        private readonly IBlogConsumeApiService _blogConsumeApiService;
        private readonly IDataProtector _dataProtector;
        private readonly ICommentConsumeApiService _commentConsumeApiService;
        public _BlogDetailMainComponentPartial(IBlogConsumeApiService blogConsumeApiService, IDataProtectionProvider dataProtector, ICommentConsumeApiService commentConsumeApiService)
        {
            _blogConsumeApiService = blogConsumeApiService;
            _dataProtector = dataProtector.CreateProtector("BlogController");
            _commentConsumeApiService = commentConsumeApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataId = int.Parse(_dataProtector.Unprotect(id));
            var commentCount = await _commentConsumeApiService.GetBlogCommentCountAsync(dataId);
            ViewBag.CommentCount = commentCount.BlogCommentCount;
            return View(await _blogConsumeApiService.GetByIdAsync("Blogs", dataId));
        }
    }
}
