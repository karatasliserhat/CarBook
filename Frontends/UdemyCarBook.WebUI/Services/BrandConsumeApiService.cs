using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class BrandConsumeApiService : GenericConsumeApiService<ResultBrandDto, CreateBrandDto, UpdateBrandDto>, IBrandConsumeApiService
    {
        public BrandConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
