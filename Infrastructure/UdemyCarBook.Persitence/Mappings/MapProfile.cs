using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Persitence.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<About, GetAboutQueryResult>().ReverseMap();
            CreateMap<About, GetAboutByIdQueryResult>().ReverseMap();
            CreateMap<About, CreateAboutCommand>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();
        }
    }
}
