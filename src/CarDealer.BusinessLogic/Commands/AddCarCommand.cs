

using CarDealer.BusinessLogic.Dtos;
using CarDealer.BusinessLogic.Wrappers;
using CarDealer.DataAccess.Model;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using MediatR;
using System.Reflection.Metadata;

namespace CarDealer.BusinessLogic.Commands
{
    public class AddCarCommand : IRequest<Result<int>>
    {
        public AddCarCommand(int carId,
            string model,
            Brand brand,
            Color color)
        {
            CarId = carId;
            Model = model;
            Brand = brand;
            Color = color;

        }

        public int CarId { get; }
        public string Model { get; }
        public Brand Brand { get; }
        public Color Color { get; }
    }

    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, Result<int>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;

        public AddCarCommandHandler(
            ICarRepository carRepository,
            IBrandRepository brandRepository,
            IColorRepository colorRepository)
        {
            _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _colorRepository = colorRepository ?? throw new ArgumentNullException(nameof(colorRepository));
        }

        public async Task<Result<int>> Handle(AddCarCommand command, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetAsync(command.CarId);
            if (car.Id != command.CarId)
            {
                return Result.Fail<int>($"Car not found with Id= '{command.CarId}'");
            }

            var newCar = new Car()
            {
                Brand = car.Brand,
                Color = car.Color,
                Model = car.Model,
            };

            var result = await _carRepository.AddAsync(newCar);
            return Result.Success(result.Id);
        }
    }
}
