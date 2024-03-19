using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class CommentConsumeApiService : GenericConsumeApiService<ResultCommentDto, CreateCommentDto, UpdateCommentDto>, ICommentConsumeApiService
    {
        private readonly HttpClient _client;
        public CommentConsumeApiService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task<List<GetCommentByBlogIdDto>> GetCommentByBlogIdListAsync(int id)
        {
            return await _client.GetFromJsonAsync<List<GetCommentByBlogIdDto>>($"Comments/GetCommentByBlogId/{id}");
        }
    }
}
