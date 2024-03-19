using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogConsumeApiService _blogConsumeApiService;

        public BlogController(IBlogConsumeApiService blogConsumeApiService)
        {
            _blogConsumeApiService = blogConsumeApiService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            return View(await _blogConsumeApiService.GetListAsync("Blogs", "GetBlogWithAuthorAndCategoryList"));
        }

        public IActionResult BlogDetail(int id)
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            return View();
        }
    }
}
