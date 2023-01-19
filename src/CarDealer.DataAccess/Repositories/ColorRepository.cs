using CarDealer.DataAccess.Context;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using CarDealer.DataAccess.Model.Repositories.Interfaces.Base;

namespace CarDealer.DataAccess.Model.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        private readonly CarDealerContext _context;
        public ColorRepository(CarDealerContext context) : base(context)
        {
            _context = context;
        }
        protected override Color CreateEntity(int id)
        {
            return new Color { Id = id };
        }
    }
}
