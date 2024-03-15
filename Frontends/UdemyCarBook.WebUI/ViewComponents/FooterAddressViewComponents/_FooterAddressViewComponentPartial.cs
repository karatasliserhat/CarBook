using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.FooterAddressViewComponents
{
    public class _FooterAddressViewComponentPartial:ViewComponent
    {
        private readonly IFooterAddressConsumeApiService _footerAddressService;

        public _FooterAddressViewComponentPartial(IFooterAddressConsumeApiService footerAddressService)
        {
            _footerAddressService = footerAddressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _footerAddressService.GetListAsync("FooterAddresses"));
        }
    }
}
