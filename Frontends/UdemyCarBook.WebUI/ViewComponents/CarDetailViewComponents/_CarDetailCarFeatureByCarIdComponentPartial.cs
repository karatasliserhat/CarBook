using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarFeatureByCarIdComponentPartial : ViewComponent
    {
        private readonly ICarFeatureConsumeApiService _service;
        private readonly IDataProtector _dataProtector;

        public _CarDetailCarFeatureByCarIdComponentPartial(ICarFeatureConsumeApiService service, IDataProtectionProvider dataProtector)
        {
            _service = service;
            _dataProtector = dataProtector.CreateProtector("CarController");
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var dataValue = int.Parse(_dataProtector.Unprotect(id));
            var value = await _service.GetCarFeatureListByCarId(dataValue);
            if (value is not null)
            {
                return View(value);

            }
            return View(id);

        }
    }
}
