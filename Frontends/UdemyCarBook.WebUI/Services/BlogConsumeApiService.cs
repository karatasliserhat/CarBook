using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class BlogConsumeApiService : GenericConsumeApiService<ResultBlogDto, CreateBlogDto, UpdateBlogDto>, IBlogConsumeApiService
    {
        public BlogConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
