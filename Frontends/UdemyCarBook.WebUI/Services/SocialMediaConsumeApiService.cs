using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class SocialMediaConsumeApiService : GenericConsumeApiService<ResultSocialMediaDto, CreateSocialMediaDto, UpdateSocialMediaDto>, ISocialMediaConsumeApiService
    {
        public SocialMediaConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
