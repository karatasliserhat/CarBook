using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class PricingConsumeApiService : GenericConsumeApiService<ResultPricingDto, CreatePricingDto, UpdatePricingDto>, IPricingConsumeApiService
    {
        public PricingConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
