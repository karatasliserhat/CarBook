using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Persitence.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<About, GetAboutQueryResult>().ReverseMap();
        }
    }
}
