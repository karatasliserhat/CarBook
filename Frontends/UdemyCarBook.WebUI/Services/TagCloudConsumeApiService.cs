using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class TagCloudConsumeApiService : GenericConsumeApiService<ResultTagCloudDto, CreateTagCloudDto, UpdateTagCloudDto>, ITagCloudConsumeApiService
    {
        private readonly HttpClient _client;
        public TagCloudConsumeApiService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task<List<GetTagCloudByBlogIdDto>> GetTagCloudByBlogIdListAsync(int id)
        {
            return await _client.GetFromJsonAsync<List<GetTagCloudByBlogIdDto>>($"TagClouds/GetTagCloudByBlogIdList/{id}");
        }
    }
}
