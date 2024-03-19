using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial : ViewComponent
    {
        private readonly IBlogConsumeApiService _blogConsumeApiService;
        private readonly IDataProtector _dataProtector;

        public _BlogDetailsAuthorAboutComponentPartial(IBlogConsumeApiService blogConsumeApiService, IDataProtectionProvider dataProtector)
        {
            _blogConsumeApiService = blogConsumeApiService;
            _dataProtector = dataProtector.CreateProtector("BlogController");
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataId = int.Parse(_dataProtector.Unprotect(id));
            return View(await _blogConsumeApiService.GetBlogWithAuthorListAsync(dataId));
        }
    }
}
