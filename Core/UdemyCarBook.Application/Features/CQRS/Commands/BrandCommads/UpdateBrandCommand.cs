namespace UdemyCarBook.Application.Features.CQRS.Commands
{
    public class UpdateBrandCommand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
