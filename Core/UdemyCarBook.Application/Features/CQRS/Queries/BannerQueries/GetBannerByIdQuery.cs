namespace UdemyCarBook.Application.Features.CQRS.Queries
{
    public class GetBannerByIdQuery
    {
        public int BannerId { get; set; }

        public GetBannerByIdQuery(int bannerId)
        {
            BannerId = bannerId;
        }
    }
}
