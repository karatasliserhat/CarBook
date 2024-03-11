using UdemyCarBook.Application.Features.CQRS.Commands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCarCommand removeCarCommand)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(removeCarCommand.CarId));
        }
    }
}
