using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Queries;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery getBrandByIdQuery)
        {
            return _mapper.Map<GetBrandByIdQueryResult>(await _repository.GetByIdAsync(getBrandByIdQuery.BrandId));
        }
    }
}
