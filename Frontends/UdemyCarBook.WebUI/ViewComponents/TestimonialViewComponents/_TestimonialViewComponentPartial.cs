using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialViewComponentPartial : ViewComponent
    {
        private readonly ITestimonialConsumeApiService _testimonialService;

        public _TestimonialViewComponentPartial(ITestimonialConsumeApiService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _testimonialService.GetListAsync("Testimonials"));
        }
    }
}
