using AutoMapper;
using UdemyCarBook.Application.Features.CQRS.Commands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            await _repository.UpdateAsync(_mapper.Map<Car>(updateCarCommand));
        }
    }
}
