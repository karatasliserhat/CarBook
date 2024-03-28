using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class CarPricingConsumeApiService : GenericConsumeApiService<ResultCarPricingDto, CreateCarPricingDto, UpdateCarPricingDto>, ICarPricingConsumeApiServe
    {
        private readonly HttpClient _httpClient;
        public CarPricingConsumeApiService(HttpClient client) : base(client)
        {
           _httpClient = client;
        }

        public async Task<List<GetCarPricingWithTimePeriodDto>> GetCarPricingWithTimePeriod()
        {
            return await _httpClient.GetFromJsonAsync<List<GetCarPricingWithTimePeriodDto>>("CarPricings/GetCarPricingWithTimePeriod");
        }
    }
}
