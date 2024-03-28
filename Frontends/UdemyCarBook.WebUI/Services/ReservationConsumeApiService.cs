using UdemyCarBook.Dto.Dtos;
using UdemyCarBook.WebUI.Abstracts;

namespace UdemyCarBook.WebUI.Services
{
    public class ReservationConsumeApiService : GenericConsumeApiService<ResultReservationDto, CreateReservationDto, UpdateReservationDto>, IReservationConsumeApiService
    {
        public ReservationConsumeApiService(HttpClient client) : base(client)
        {
        }
    }
}
