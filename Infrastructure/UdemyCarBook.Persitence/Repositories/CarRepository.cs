using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persitence.Context;

namespace UdemyCarBook.Persitence.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<Car>> GetCarWithBrand()
        {
            return await _carBookContext.Cars.Include(x => x.Brand).AsNoTracking().ToListAsync();
        }
    }
}
