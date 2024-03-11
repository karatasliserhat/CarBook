namespace UdemyCarBook.Application.Features.CQRS.Commands
{
    public class RemoveAboutCommand
    {
        public int AboutId { get; set; }
        public RemoveAboutCommand(int aboutId)
        {
            AboutId = aboutId;
        }
    }
}
