namespace UdemyCarBook.Application.Features.CQRS.Queries
{
    public class GetBrandByIdQuery
    {
        public int BrandId { get; set; }

        public GetBrandByIdQuery(int brandId)
        {
            BrandId = brandId;
        }
    }
}
