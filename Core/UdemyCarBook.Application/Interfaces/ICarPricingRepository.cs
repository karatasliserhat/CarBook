using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarWithPricingAndBrandList();
        Task<List<CarPricing>> GetCarWithPricingAndBrandDayList();
    }
}
