using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class CarConsumeApiService : GenericConsumeApiService<ResultCarDto, CreateCarDto, UpdateCarDto>, ICarConsumeApiService
    {
        public CarConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
