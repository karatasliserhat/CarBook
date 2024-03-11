using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Commands;
using UdemyCarBook.Application.Features.CQRS.Results;
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

            CreateMap<Banner, GetBannerQueryResult>().ReverseMap();
            CreateMap<Banner, GetBannerByIdQueryResult>().ReverseMap();
            CreateMap<Banner, CreateBannerCommand>().ReverseMap();
            CreateMap<Banner, UpdateBannerCommand>().ReverseMap();

        }
    }
}
