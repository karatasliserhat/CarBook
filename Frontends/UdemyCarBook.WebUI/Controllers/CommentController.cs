using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IDataProtector _dataProtector;
        private readonly ICommentConsumeApiService _commentService;

        public CommentController(IDataProtectionProvider dataProtector, ICommentConsumeApiService commentService)
        {
            _dataProtector = dataProtector.CreateProtector("BlogController");
            _commentService = commentService;
        }

        public PartialViewResult CommentAdd()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> CommentAdd(CreateCommentDto createCommentDto, string id)
        {
            var blogId = int.Parse(_dataProtector.Unprotect(id));
            createCommentDto.BlogId = blogId;
            createCommentDto.CreatedDate = DateTime.UtcNow;
            var response = await _commentService.CreateAsync("Comments", createCommentDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogDetail", "Blog", new { id = id });
            }
            return View();
        }
    }
}
