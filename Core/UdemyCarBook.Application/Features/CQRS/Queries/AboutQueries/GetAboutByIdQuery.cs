﻿namespace UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public int AboutId { get; set; }

        public GetAboutByIdQuery(int aboutId)
        {
            AboutId = aboutId;
        }
    }
}
