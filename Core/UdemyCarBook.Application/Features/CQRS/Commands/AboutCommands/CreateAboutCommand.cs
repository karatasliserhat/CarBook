﻿namespace UdemyCarBook.Application.Features.CQRS.Commands
{
    public class CreateAboutCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}
