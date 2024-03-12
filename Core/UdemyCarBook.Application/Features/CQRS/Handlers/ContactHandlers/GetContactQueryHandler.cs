using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{

    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;
        public GetContactQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            return _mapper.Map<List<GetContactQueryResult>>(await _repository.GetAllAsync());
        }
    }
}
