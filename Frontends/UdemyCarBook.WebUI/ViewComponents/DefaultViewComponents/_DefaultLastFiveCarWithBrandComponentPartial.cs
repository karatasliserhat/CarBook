using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLastFiveCarWithBrandComponentPartial : ViewComponent
    {
        private readonly ICarConsumeApiService _carConsumeService;

        public _DefaultLastFiveCarWithBrandComponentPartial(ICarConsumeApiService carConsumeService)
        {
            _carConsumeService = carConsumeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _carConsumeService.GetListAsync("Cars", "GetLastFiveCarWithBrand"));
        }
    }
}
