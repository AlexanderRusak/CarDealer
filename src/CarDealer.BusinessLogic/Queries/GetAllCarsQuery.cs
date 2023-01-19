using CarDealer.BusinessLogic.Dtos;
using CarDealer.BusinessLogic.Wrappers;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using MediatR;

namespace CarDealer.BusinessLogic.Queries
{
    public class GetAllCarsQuery : IRequest<Result<IEnumerable<CarDto>>>
    {
    }

    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, Result<IEnumerable<CarDto>>>
    {

        private readonly ICarRepository _carRepository;

        public GetAllCarsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

       async Task<Result<IEnumerable<CarDto>>> IRequestHandler<GetAllCarsQuery, Result<IEnumerable<CarDto>>>.Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var result =(await _carRepository.GetAsync()).Select(car => new CarDto
            {
                Brand = car.Brand.Name,
                Model = car.Model,
                Color = car.Color.Name
            });
            return Result.Success(result);
        }
    }
}
