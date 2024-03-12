using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Commands;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Features.Mediator.Commands;
using UdemyCarBook.Application.Features.Mediator.Results;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Mappings
{
    public class MapProfile : Profile
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

            CreateMap<Brand, GetBrandQueryResult>().ReverseMap();
            CreateMap<Brand, GetBrandByIdQueryResult>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();

            CreateMap<Car, GetCarQueryResult>().ReverseMap();
            CreateMap<Car, GetCarByIdQueryResult>().ReverseMap();
            CreateMap<Car, GetCarWithBrandQueryResult>().ForMember(x => x.BrandName, opt => opt.MapFrom(x => x.Brand.Name)).ReverseMap();
            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, UpdateCarCommand>().ReverseMap();


            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();


            CreateMap<Contact, GetContactQueryResult>().ReverseMap();
            CreateMap<Contact, GetContactByIdQueryResult>().ReverseMap();
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();

        }
    }
}
