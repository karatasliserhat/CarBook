using Microsoft.AspNetCore.SignalR;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.WebApi.Hubs
{
    public class MyHub : Hub
    {
        private readonly IStatisticRepository _statisticRepository;

        public MyHub(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task SendStatistic()
        {
            var carCount = await _statisticRepository.GetCarCount();
            await Clients.All.SendAsync("ReceiveCarCount", carCount);

            var lokasyonCount = await _statisticRepository.GetLocationCount();
            await Clients.All.SendAsync("ReceiveLokasyonCount", lokasyonCount);

            var authorCount = await _statisticRepository.GetAuthorCount();
            await Clients.All.SendAsync("ReceiveAuthorCount", authorCount);

            var blogCount = await _statisticRepository.GetBlogCount();
            await Clients.All.SendAsync("ReceiveBlogCount", blogCount);

            var brandCount = await _statisticRepository.GetBrandCount();
            await Clients.All.SendAsync("ReceiveBrandCount", brandCount);

            var getDailiyCarPricingAvgPrice = await _statisticRepository.GetDailiyCarPricingAvgPrice();
            await Clients.All.SendAsync("ReceiveGetDailiyCarPricingAvgPrice", getDailiyCarPricingAvgPrice.ToString("₺ 0.00"));

            var getWeeklyCarPricingAvgPrice = await _statisticRepository.GetWeeklyCarPricingAvgPrice();
            await Clients.All.SendAsync("ReceiveGetWeeklyCarPricingAvgPrice", getWeeklyCarPricingAvgPrice.ToString("₺ 0.00"));

            var getHourslyCarPricingAvgPrice = await _statisticRepository.GetHourslyCarPricingAvgPrice();
            await Clients.All.SendAsync("ReceiveGetHourslyCarPricingAvgPrice", getHourslyCarPricingAvgPrice.ToString("₺ 0.00"));

            var getCarCountByTransmissonAuto = await _statisticRepository.GetCarCountByTransmissonAuto();
            await Clients.All.SendAsync("ReceiveGetCarCountByTransmissonAuto", getCarCountByTransmissonAuto);

            var getBrandNameByMaxCar = await _statisticRepository.GetBrandNameByMaxCar();
            await Clients.All.SendAsync("ReceiveGetBrandNameByMaxCar", getBrandNameByMaxCar);

            var getTitleByMaxBlogComment = await _statisticRepository.GetTitleByMaxBlogComment();
            await Clients.All.SendAsync("ReceiveGetTitleByMaxBlogComment", getTitleByMaxBlogComment);

            var getCarCountByKmSmallerThen1000 = await _statisticRepository.GetCarCountByKmSmallerThen1000();
            await Clients.All.SendAsync("ReceiveGetCarCountByKmSmallerThen1000", getCarCountByKmSmallerThen1000);

            var getCarCountByFuelGassolineOrDiesel = await _statisticRepository.GetCarCountByFuelGassolineOrDiesel();
            await Clients.All.SendAsync("ReceiveGetCarCountByFuelGassolineOrDiesel", getCarCountByFuelGassolineOrDiesel);

            var getCarCountByFuelElectic = await _statisticRepository.GetCarCountByFuelElectic();
            await Clients.All.SendAsync("ReceiveGetCarCountByFuelElectic", getCarCountByFuelElectic);

            var getCarBrandAndModelByRentPriceDailyMin = await _statisticRepository.GetCarBrandAndModelByRentPriceDailyMin();
            await Clients.All.SendAsync("ReceiveGetCarBrandAndModelByRentPriceDailyMin", getCarBrandAndModelByRentPriceDailyMin);

            var getCarBrandAndModelByRentPriceDailyMax = await _statisticRepository.GetCarBrandAndModelByRentPriceDailyMax();
            await Clients.All.SendAsync("ReceiveGetCarBrandAndModelByRentPriceDailyMax", getCarBrandAndModelByRentPriceDailyMax);


        }
    }
}
