using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class ServiceConsumeApiService : GenericConsumeApiService<ResultServiceDto, CreateServiceDto, UpdateServiceDto>, IServiceConsumeApiService
    {
        public ServiceConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
