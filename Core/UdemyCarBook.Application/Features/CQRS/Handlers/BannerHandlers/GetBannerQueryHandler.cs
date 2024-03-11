using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public GetBannerQueryHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            return _mapper.Map<List<GetBannerQueryResult>>(await _repository.GetAllAsync());
        }
    }
}
