namespace UdemyCarBook.Application.Features.CQRS.Queries
{
    public class GetCategoryByIdQuery
    {
        public int CategoryId { get; set; }

        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
