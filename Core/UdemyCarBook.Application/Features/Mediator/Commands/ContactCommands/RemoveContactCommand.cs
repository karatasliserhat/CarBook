﻿using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands
{
    public class RemoveContactCommand:IRequest
    {
        public int ContactId { get; set; }

        public RemoveContactCommand(int contactId)
        {
            ContactId = contactId;
        }
    }
}
