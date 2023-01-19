using CarDealer.BusinessLogic.Wrappers;
using CarDealer.DataAccess.Model;
using CarDealer.DataAccess.Model.Repositories;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using MediatR;

namespace CarDealer.BusinessLogic.Commands
{
    public class AddDealerCarCommand : IRequest<Result<int>>
    {

        public AddDealerCarCommand(
            int dealerCarId,
            decimal price,
            Dealer dealer,
            Car car)
        {
            DealerCarId = dealerCarId;
            Price = price;
            Dealer = dealer;
            Car = car;
        }

        public int DealerCarId { get; }

        public decimal Price { get; }
        public Dealer Dealer { get; }

        public Car Car { get; }

    }

    public class AddDealerCarsCommandHandler : IRequestHandler<AddDealerCarCommand, Result<int>>
    {

        private readonly ICarRepository _carRepository;
        private readonly IDealerRepository _dealerRepository;
        private readonly IDealerCarRepository _dealerCarRepository;

        public AddDealerCarsCommandHandler(
            ICarRepository carRepository,
            IDealerRepository dealerRepository,
            IDealerCarRepository dealerCarRepository)
        {
            _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
            _dealerRepository = dealerRepository ?? throw new ArgumentNullException(nameof(dealerRepository));
            _dealerCarRepository = dealerCarRepository ?? throw new ArgumentNullException(nameof(dealerCarRepository));
        }
        public async Task<Result<int>> Handle(AddDealerCarCommand command, CancellationToken cancellationToken)
        {
            var dealerCar = await _dealerCarRepository.GetAsync(command.DealerCarId);
            if (dealerCar.Id != command.DealerCarId)
            {
                return Result.Fail<int>($"Car not found with Id='{command.DealerCarId}'");
            }

            var newDealerCar = new DealerCar()
            {
                Car = dealerCar.Car,
                Price = dealerCar.Price,
                Dealer = dealerCar.Dealer,

            };

            var result =await _dealerCarRepository.AddAsync(newDealerCar);
            return Result.Success(result.Id);
        }
    }
}
