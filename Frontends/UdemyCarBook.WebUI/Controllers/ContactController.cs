using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactConsumeApiService _contactConsumeApiService;

        public ContactController(IContactConsumeApiService contactConsumeApiService)
        {
            _contactConsumeApiService = contactConsumeApiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var response = await _contactConsumeApiService.CreateAsync("Contacts", createContactDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
