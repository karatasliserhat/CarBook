using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Commands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public CreateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateBannerCommand createBannerCommand)
        {
            await _repository.CreateAsync(_mapper.Map<Banner>(createBannerCommand));    
        }
    }
}
