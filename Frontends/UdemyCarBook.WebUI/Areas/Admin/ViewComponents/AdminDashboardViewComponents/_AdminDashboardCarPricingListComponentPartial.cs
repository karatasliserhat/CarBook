using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.ViewComponents.AdminDashboardViewComponents
{
    public class _AdminDashboardCarPricingListComponentPartial : ViewComponent
    {
        private readonly ICarPricingConsumeApiServe _carPricingConsumeApiServe;

        public _AdminDashboardCarPricingListComponentPartial(ICarPricingConsumeApiServe carPricingConsumeApiServe)
        {
            _carPricingConsumeApiServe = carPricingConsumeApiServe;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await _carPricingConsumeApiServe.GetCarPricingWithTimePeriod());
        }
    }
}
