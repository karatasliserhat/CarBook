using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Queries;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery getContactByIdQuery)
        {
            return _mapper.Map<GetContactByIdQueryResult>(await _repository.GetByIdAsync(getContactByIdQuery.ContactId));
        }
    }
}
