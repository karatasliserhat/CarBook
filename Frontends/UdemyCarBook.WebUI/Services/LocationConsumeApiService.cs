using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class LocationConsumeApiService : GenericConsumeApiService<ResultLocationDto, CreateLocationDto, UpdateLocationDto>, ILocationConsumeApiService
    {
        public LocationConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
