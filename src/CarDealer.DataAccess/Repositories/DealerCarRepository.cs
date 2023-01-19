using CarDealer.DataAccess.Context;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using CarDealer.DataAccess.Model.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.DataAccess.Model.Repositories
{
    public class DealerCarRepository : Repository<DealerCar>, IDealerCarRepository
    {

        private readonly CarDealerContext _context;
        public DealerCarRepository(CarDealerContext context) : base(context)
        {
            _context = context;
        }

        protected override DealerCar CreateEntity(int id)
        {
            return new DealerCar { Id = id };
        }

        public  ICollection<DealerCar> GetAsync()
        {
            return _context.DealerCars.Include(x => x.Dealer).Include(x => x.Car).Include(x=>x.Car.Brand).Include(x=>x.Car.Color).ToList();
        }
    }
}
