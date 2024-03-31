using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]

    public class AdminCarController : Controller
    {
        private readonly ICarConsumeApiService _carConsumerApiService;
        private readonly IDataProtector _dataProtect;
        private readonly IBrandConsumeApiService _brandConsumeApiService;
        public AdminCarController(ICarConsumeApiService carConsumerApiService, IDataProtectionProvider dataProtect, IBrandConsumeApiService brandConsumeApiService)
        {
            _carConsumerApiService = carConsumerApiService;
            _dataProtect = dataProtect.CreateProtector("AdminCarController");
            _brandConsumeApiService = brandConsumeApiService;
        }

        public async Task GetBrandListSelect()
        {
            var brandValues = await _brandConsumeApiService.GetListAsync("Brands");

            ViewBag.BrandSelectValue = new SelectList(brandValues, "BrandId", "Name");
        }
        public async Task<IActionResult> Index()
        {
            var values = await _carConsumerApiService.GetListAsync("cars", "GetCarWithBrand");

            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.CarId.ToString()));
            return View(values);
        }

        public async Task<IActionResult> CreateCar()
        {
            await GetBrandListSelect();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var response = await _carConsumerApiService.CreateAsync("Cars", createCarDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {

            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var data = await _carConsumerApiService.GetByIdUpdateAsync("Cars", dataValue);
            await GetBrandListSelect();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarDto updateCarDto)
        {
            var response = await _carConsumerApiService.UpdateAsync("Cars", updateCarDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _carConsumerApiService.RemoveAsync("Cars", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
       
    }
}
