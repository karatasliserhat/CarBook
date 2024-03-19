using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCloudTagByBlogComponentPartial : ViewComponent
    {
        private readonly ITagCloudConsumeApiService _tagCloudConsumeApiService;
        private readonly IDataProtector _dataProtector;
        public _BlogDetailCloudTagByBlogComponentPartial(ITagCloudConsumeApiService tagCloudConsumeApiService, IDataProtectionProvider dataProtector)
        {
            _tagCloudConsumeApiService = tagCloudConsumeApiService;
            _dataProtector = dataProtector.CreateProtector("BlogController");
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataId = int.Parse(_dataProtector.Unprotect(id));

            return View(await _tagCloudConsumeApiService.GetTagCloudByBlogIdListAsync(dataId));
        }
    }
}
