using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persitence.Context;

namespace UdemyCarBook.Persitence.Repositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarWithPricingAndBrandDayList()
        {
            return await _context.CarPricings.Include(x => x.Pricing).Include(x => x.Car).ThenInclude(x => x.Brand).Where(x => x.PricingId==3).ToListAsync();
        }

        public async Task<List<CarPricing>> GetCarWithPricingAndBrandList()
        {

            return await _context.CarPricings.Include(x => x.Pricing).Include(x => x.Car).ThenInclude(x => x.Brand).ToListAsync();
        }
    }
}
