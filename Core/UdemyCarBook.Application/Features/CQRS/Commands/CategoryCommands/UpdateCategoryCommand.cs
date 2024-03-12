namespace UdemyCarBook.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommand
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
