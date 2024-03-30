using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutViewComponentPartial : ViewComponent
    {
        private readonly IFooterAddressConsumeApiService _footerAddressConsumeApiService;

        public _FooterUILayoutViewComponentPartial(IFooterAddressConsumeApiService footerAddressConsumeApiService)
        {
            _footerAddressConsumeApiService = footerAddressConsumeApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _footerAddressConsumeApiService.GetListAsync("FooterAddresses"));
        }
    }
}
