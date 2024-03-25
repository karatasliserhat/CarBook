using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AdminStatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
