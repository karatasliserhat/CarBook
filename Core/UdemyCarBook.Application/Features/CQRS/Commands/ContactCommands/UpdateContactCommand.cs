namespace UdemyCarBook.Application.Features.CQRS.Commands
{
    public class UpdateContactCommand
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SenDate { get; set; }
    }
}
