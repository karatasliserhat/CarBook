using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class TestimonialConsumeApiService : GenericConsumeApiService<ResultTestimonialDto, CreateTestimonialDto, UpdateTestimonialDto>, ITestimonialConsumeApiService
    {
        public TestimonialConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
