using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        
        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
