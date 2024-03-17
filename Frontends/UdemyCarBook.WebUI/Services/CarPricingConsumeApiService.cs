using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class CarPricingConsumeApiService : GenericConsumeApiService<ResultCarPricingDto, CreateCarPricingDto, UpdateCarPricingDto>, ICarPricingConsumeApiServe
    {
        public CarPricingConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
