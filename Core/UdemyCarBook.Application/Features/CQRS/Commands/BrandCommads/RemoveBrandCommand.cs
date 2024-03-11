namespace UdemyCarBook.Application.Features.CQRS.Commands
{
    public class RemoveBrandCommand
    {
        public int BrandId { get; set; }

        public RemoveBrandCommand(int brandId)
        {
            BrandId = brandId;
        }
    }
}
