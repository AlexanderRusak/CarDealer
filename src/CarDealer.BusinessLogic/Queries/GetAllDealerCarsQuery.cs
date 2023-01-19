using CarDealer.BusinessLogic.Dtos;
using CarDealer.BusinessLogic.Wrappers;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using MediatR;

namespace CarDealer.BusinessLogic.Queries
{
    public class GetAllDealerCarsQuery : IRequest<Result<IEnumerable<CarDealerDto>>>
    {
    }

    public class GetAllDealerCarsQueryHandler : IRequestHandler<GetAllDealerCarsQuery, Result<IEnumerable<CarDealerDto>>>
    {

        private readonly IDealerCarRepository _dealerCarRepository;

        public GetAllDealerCarsQueryHandler(IDealerCarRepository dealerCarRepository)
        {
            _dealerCarRepository = dealerCarRepository ?? throw new ArgumentNullException(nameof(dealerCarRepository));
        }

        async Task<Result<IEnumerable<CarDealerDto>>> IRequestHandler<GetAllDealerCarsQuery, Result<IEnumerable<CarDealerDto>>>.Handle(GetAllDealerCarsQuery request, CancellationToken cancellationToken)
        {
            var result = (await _dealerCarRepository.GetAsync()).Select(dealerCar =>
            new CarDealerDto
            {
                Id = dealerCar.Id,
                Brand = dealerCar.Car.Brand.Name,
                Color = dealerCar.Car.Color.Name,
                Model = dealerCar.Car.Model,
                DealerName = dealerCar.Dealer.Name,
                DealerPhone = dealerCar.Dealer.Phone,
                Price = dealerCar.Price,
            }
            );

            return Result.Success(result);
        }
    }
}
