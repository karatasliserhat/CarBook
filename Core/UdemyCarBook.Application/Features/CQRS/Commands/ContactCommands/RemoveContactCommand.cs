namespace UdemyCarBook.Application.Features.CQRS.Commands
{
    public class RemoveContactCommand
    {
        public int ContactId { get; set; }

        public RemoveContactCommand(int contactId)
        {
            ContactId = contactId;
        }
    }
}
