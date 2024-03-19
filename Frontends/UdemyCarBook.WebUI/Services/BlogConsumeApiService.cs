using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class BlogConsumeApiService : GenericConsumeApiService<ResultBlogDto, CreateBlogDto, UpdateBlogDto>, IBlogConsumeApiService
    {
        private readonly HttpClient _httpClient;
        public BlogConsumeApiService(HttpClient client) : base(client)
        {
            _httpClient = client;
        }

        public async Task<List<ResultLastThreeBlogWithAuthorDto>> GetLastThreeBlogWithAuthorList()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultLastThreeBlogWithAuthorDto>>("Blogs/GetLastThreeBlogsWithAuthorsAndCategory");
        }
    }
}
