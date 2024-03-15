using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class BannerConsumeApiService : GenericConsumeApiService<ResultBannerDto, CreateBannerDto, UpdateBannerDto>, IBannerConsumeApiService
    {
        public BannerConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
