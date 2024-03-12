using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Results;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;
        public GetCarWithBrandQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarWithBrand();

            return _mapper.Map<List<GetCarWithBrandQueryResult>>(values);
        }
    }
}
