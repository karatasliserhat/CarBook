using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogViewComponentPartial : ViewComponent
    {
        private readonly IBlogConsumeApiService _blogConsumeApiService;
        private readonly IDataProtector _dataProtector;
        public _BlogViewComponentPartial(IBlogConsumeApiService blogConsumeApiService, IDataProtectionProvider dataProvider)
        {
            _blogConsumeApiService = blogConsumeApiService;
            _dataProtector = dataProvider.CreateProtector("BlogController");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _blogConsumeApiService.GetLastThreeBlogWithAuthorList();
            values.ForEach(x => x.DataProtect = _dataProtector.Protect(x.BlogId.ToString()));
            return View(values);
        }
    }
}
