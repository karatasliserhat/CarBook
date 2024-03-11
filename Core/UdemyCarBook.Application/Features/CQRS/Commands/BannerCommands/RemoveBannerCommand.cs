namespace UdemyCarBook.Application.Features.CQRS.Commands
{
    public class RemoveBannerCommand
    {
        public int BannerId { get; set; }

        public RemoveBannerCommand(int bannerId)
        {
            BannerId = bannerId;
        }
    }
}
