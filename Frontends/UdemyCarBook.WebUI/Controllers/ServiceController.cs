using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceConsumeApiService _serviceConsume;

        public ServiceController(IServiceConsumeApiService serviceConsume)
        {
            _serviceConsume = serviceConsume;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _serviceConsume.GetListAsync("Services"));
        }
    }
}
