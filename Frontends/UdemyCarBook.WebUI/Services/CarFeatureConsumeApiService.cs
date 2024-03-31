using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class CarFeatureConsumeApiService : GenericConsumeApiService<ResultCarFeatureListByCarIdDto, CreateCarFeatureDto, UpdateCarFeatureDto>, ICarFeatureConsumeApiService
    {
        private readonly HttpClient _client;
        public CarFeatureConsumeApiService(HttpClient client) : base(client)
        {
            _client = client;
        }

        public async Task ChangeAvailableFalse(int CarFeatureId)
        {
            await _client.GetAsync($"CarFeatures/ChangeCarFeatureAvailableFalse/{CarFeatureId}");
        }

        public async Task ChangeAvailableTrue(int CarFeatureId)
        {
            await _client.GetAsync($"CarFeatures/ChangeCarFeatureAvailableTrue/{CarFeatureId}");
        }

        public async Task<List<ResultCarFeatureListByCarIdDto>> GetCarFeatureListByCarId(int CarId)
        {
            return await _client.GetFromJsonAsync<List<ResultCarFeatureListByCarIdDto>>($"CarFeatures/{CarId}");
        }
    }
}
