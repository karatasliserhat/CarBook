using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AdminContactController : Controller
    {
        private readonly IContactConsumeApiService _ContactConsumeApiService;
        private readonly IDataProtector _dataProtect;
        public AdminContactController(IContactConsumeApiService ContactConsumeApiService, IDataProtectionProvider dataProtect)
        {
            _ContactConsumeApiService = ContactConsumeApiService;
            _dataProtect = dataProtect.CreateProtector("AdminContactController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _ContactConsumeApiService.GetListAsync("Contacts");
            values.ForEach(x => x.DataProtect = _dataProtect.Protect(x.ContactId.ToString()));
            return View(values);
        }

        public async Task<IActionResult> Update(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            return View(await _ContactConsumeApiService.GetByIdUpdateAsync("Contacts", dataValue));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            var response = await _ContactConsumeApiService.UpdateAsync("Contacts", updateContactDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataValue = int.Parse(_dataProtect.Unprotect(id));
            var response = await _ContactConsumeApiService.RemoveAsync("Contacts", dataValue);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
