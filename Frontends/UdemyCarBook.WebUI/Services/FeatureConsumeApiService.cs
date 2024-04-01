using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class FeatureConsumeApiService : GenericConsumeApiService<ResultFeatureDto, CreateFeatureDto, UpdateFeatureDto>, IFeatureConsumeApiService
    {
        private readonly HttpClient _httpClient;
        public FeatureConsumeApiService(HttpClient client) : base(client)
        {
            _httpClient = client;
        }

        public async Task<List<ResultFeatureCarIdListDto>> GetFeatureListAndCarId()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultFeatureCarIdListDto>>("Features");
        }
    }
}
