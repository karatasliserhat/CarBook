using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries;
using UdemyCarBook.Application.Features.Mediator.Results;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetHourslyCarPricingAvgPriceQueryHandler : IRequestHandler<GetHourslyCarPricingAvgPriceQuery, GetHourslyCarPricingAvgPriceQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetHourslyCarPricingAvgPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetHourslyCarPricingAvgPriceQueryResult> Handle(GetHourslyCarPricingAvgPriceQuery request, CancellationToken cancellationToken)
        {
            return new GetHourslyCarPricingAvgPriceQueryResult { MonthlyAmount = await _statisticRepository.GetHourslyCarPricingAvgPrice() };
        }
    }
}
