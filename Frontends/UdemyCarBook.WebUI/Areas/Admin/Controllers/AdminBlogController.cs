﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminBlogController : Controller
    {
        private readonly IBlogConsumeApiService _blogConsumeApiService;
        private readonly ICategoryConsumeApiService _categoryConsumeApiService;
        private readonly IDataProtector _dataProtector;
        public AdminBlogController(IBlogConsumeApiService blogConsumeApiService, ICategoryConsumeApiService categoryConsumeApiService, IDataProtectionProvider dataProtector)
        {
            _blogConsumeApiService = blogConsumeApiService;
            _categoryConsumeApiService = categoryConsumeApiService;
            _dataProtector = dataProtector.CreateProtector("AdminBlogController");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _blogConsumeApiService.GetBlogWithAuthorAndCategoryListAsync();
            values.ForEach(x => x.DataProtect = _dataProtector.Protect(x.BlogId.ToString()));
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dataId = int.Parse(_dataProtector.Unprotect(id));
            var response = await _blogConsumeApiService.RemoveAsync("Blogs", dataId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
