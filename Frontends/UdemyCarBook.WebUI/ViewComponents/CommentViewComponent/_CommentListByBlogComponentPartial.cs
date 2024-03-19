using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.CommentViewComponent
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly ICommentConsumeApiService _commentConsumeApiService;
        private readonly IDataProtector _dataProtector;
        public _CommentListByBlogComponentPartial(ICommentConsumeApiService commentConsumeApiService, IDataProtectionProvider dataProtector)
        {
            _commentConsumeApiService = commentConsumeApiService;
            _dataProtector = dataProtector.CreateProtector("BlogController");
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataId = int.Parse(_dataProtector.Unprotect(id));
            return View(await _commentConsumeApiService.GetCommentByBlogIdListAsync(dataId));
        }
    }
}
