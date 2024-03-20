using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
