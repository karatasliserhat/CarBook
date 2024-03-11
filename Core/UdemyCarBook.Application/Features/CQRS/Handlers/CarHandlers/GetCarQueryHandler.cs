using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public GetCarQueryHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            return  _mapper.Map<List<GetCarQueryResult>>(await _repository.GetAllAsync());
        }
    }
}
