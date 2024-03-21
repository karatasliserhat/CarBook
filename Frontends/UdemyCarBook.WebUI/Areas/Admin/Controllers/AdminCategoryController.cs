using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryConsumeApiService _CategoryConsumeApiService;
        private readonly IDataProtector _dataProtect;
        public AdminCategoryController(ICategoryConsumeApiService CategoryConsumeApiService, IDataProtectionProvider dataProtect)
        {
            _CategoryConsumeApiService = CategoryConsumeApiService;
            _dataProtect = dataProtect.CreateProtector("AdminCategoryController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _CategoryConsumeApiService.GetListAsync("Categories");
            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.CategoryId.ToString()));
            return View(values);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var response = await _CategoryConsumeApiService.CreateAsync("Categories", createCategoryDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            return View(await _CategoryConsumeApiService.GetByIdUpdateAsync("Categories", dataValue));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var response = await _CategoryConsumeApiService.UpdateAsync("Categories", updateCategoryDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _CategoryConsumeApiService.RemoveAsync("Categories", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
