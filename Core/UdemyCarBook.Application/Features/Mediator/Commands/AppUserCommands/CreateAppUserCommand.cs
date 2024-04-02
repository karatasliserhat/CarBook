using MediatR;
using UdemyCarBook.Application.Enums;

namespace UdemyCarBook.Application.Features.Mediator.Commands
{
    public class CreateAppUserCommand : IRequest
    {
        public string AppUserName { get; set; }
        public string Password { get; set; }
        public int AppRoleId { get; set; }
    }
}
