using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial : ViewComponent
    {
        private readonly IServiceConsumeApiService _serviceConsumeApi;

        public _ServiceComponentPartial(IServiceConsumeApiService serviceConsumeApi)
        {
            _serviceConsumeApi = serviceConsumeApi;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _serviceConsumeApi.GetListAsync("Services"));
        }
    }
}
