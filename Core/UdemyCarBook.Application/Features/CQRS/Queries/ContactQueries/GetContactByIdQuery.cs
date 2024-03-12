namespace UdemyCarBook.Application.Features.CQRS.Queries
{
    public class GetContactByIdQuery
    {
        public int ContactId { get; set; }

        public GetContactByIdQuery(int contactId)
        {
            ContactId = contactId;
        }
    }
}
