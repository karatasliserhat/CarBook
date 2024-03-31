using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IDataProtector _dataProtect;
        private readonly ICarFeatureConsumeApiService _carFeatureConsumeApiService;
        public AdminCarFeatureDetailController(IDataProtectionProvider dataProtect, ICarFeatureConsumeApiService carFeatureConsumeApiService)
        {
            _dataProtect = dataProtect.CreateProtector("AdminCarController");
            _carFeatureConsumeApiService = carFeatureConsumeApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var values = await _carFeatureConsumeApiService.GetCarFeatureListByCarId(dataValue);
            values.ForEach(x => x.DataProtect = id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureListByCarIdDto> resultCarFeatureListByCarIdDtos)
        {
            string dataProtect = null;
            foreach (var item in resultCarFeatureListByCarIdDtos)
            {
                dataProtect = item.DataProtect;
                if (item.Available)
                    await _carFeatureConsumeApiService.ChangeAvailableTrue(item.CarFeatureId);
                else
                    await _carFeatureConsumeApiService.ChangeAvailableFalse(item.CarFeatureId);

            }
            return RedirectToAction(nameof(Index), new { id = dataProtect.ToString() });
        }
    }
}
