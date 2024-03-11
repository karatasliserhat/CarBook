using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Queries;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery byIdQuery)
        {
            return _mapper.Map<GetBannerByIdQueryResult>(await _repository.GetByIdAsync(byIdQuery.BannerId));
        }
    }
}
