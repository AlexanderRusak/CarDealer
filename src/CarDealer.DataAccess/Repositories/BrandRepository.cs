using CarDealer.DataAccess.Context;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using CarDealer.DataAccess.Model.Repositories.Interfaces.Base;

namespace CarDealer.DataAccess.Model.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly CarDealerContext _context;
        public BrandRepository(CarDealerContext context) : base(context)
        {
            _context = context;
        }

        protected override Brand CreateEntity(int id)
        {
            return new Brand { Id = id };
        }
    }
}
