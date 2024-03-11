using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Queries;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutByIdQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            return _mapper.Map<GetAboutByIdQueryResult>(await _repository.GetByIdAsync(query.AboutId)
);
        }
    }
}
