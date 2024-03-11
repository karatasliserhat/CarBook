using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Commands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public RemoveBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveBannerCommand byIdQuery)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(byIdQuery.BannerId));
        }
    }
}
