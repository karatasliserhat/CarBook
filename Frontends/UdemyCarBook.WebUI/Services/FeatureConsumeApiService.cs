using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class FeatureConsumeApiService : GenericConsumeApiService<ResultFeatureDto, CreateFeatureDto, UpdateFeatureDto>, IFeatureConsumeApiService
    {
        public FeatureConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
