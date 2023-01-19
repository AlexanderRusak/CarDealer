using CarDealer.DataAccess.Context;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using CarDealer.DataAccess.Model.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.DataAccess.Model.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly CarDealerContext _context;
        public CarRepository(CarDealerContext context) : base(context)
        {
            _context = context;
        }

        protected override Car CreateEntity(int id)
        {
            return new Car { Id = id };
        }

        public new async Task<ICollection<Car>> GetAsync()
        {
            return await _context.Cars
                .Include(x => x.Color)
                .Include(x => x.Brand)
                .ToListAsync();
        }
    }
}
