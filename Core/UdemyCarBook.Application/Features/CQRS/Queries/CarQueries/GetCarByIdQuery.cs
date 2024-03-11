namespace UdemyCarBook.Application.Features.CQRS.Queries
{
    public class GetCarByIdQuery
    {
        public int CarId { get; set; }

        public GetCarByIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
