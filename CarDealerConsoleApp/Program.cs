using CarDealer.DataAccess.Context;
using CarDealer.DataAccess.Model;
using CarDealer.DataAccess.Model.Repositories;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using CarDealer.DataAccess.UnitOfWork;

using (var context = new CarDealerContext())
{
    IUnitOfWork unitOfWork = new UnitOfWork(context);
    IColorRepository colorRepo = new ColorRepository(context);
    IBrandRepository brandRepo = new BrandRepository(context);
    IDealerRepository dealerRepo = new DealerRepository(context);
    IDealerCarRepository dealerCarRepo = new DealerCarRepository(context);
    ICarRepository carRepo = new CarRepository(context);

    try
    {
        unitOfWork.BeginTransaction();

        var blackColor = new Color { Name = "Black" };
        colorRepo.AddAsync(blackColor);

        var volvoBrand = new Brand { Name = "VOLVO" };
        brandRepo.AddAsync(volvoBrand);

        var dealerVolvoSweeden = new Dealer { Name = "VOLVO Sweeden", Phone = "77772020322" };
        dealerRepo.AddAsync(dealerVolvoSweeden);
        //int two = 2;
        //int zero = 0;
        //int errorresult = two / zero;
        var volvoS80Black = new Car { Brand = volvoBrand, Color = blackColor, Model = "S80" };
        carRepo.AddAsync(volvoS80Black);

        var dealerCar = new DealerCar { Dealer = dealerVolvoSweeden, Price = 2000, Car = volvoS80Black };
        dealerCarRepo.AddAsync(dealerCar);

        unitOfWork.CommitTransaction();
    }
    catch
    {
        Console.WriteLine("Error");
        unitOfWork.RollbackTransaction();
    }


}