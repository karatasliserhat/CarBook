using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
    {
        private readonly ICarConsumeApiService _carConsumeApiService;
        private readonly IDataProtector _dataProtect;
        public _CarDetailMainCarFeatureComponentPartial(ICarConsumeApiService carConsumeApiService, IDataProtectionProvider dataProtect)
        {
            _carConsumeApiService = carConsumeApiService;
            _dataProtect = dataProtect.CreateProtector("CarController");
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));

            return View(await _carConsumeApiService.GetByIdAsync("Cars", dataValue));
        }
    }
}
