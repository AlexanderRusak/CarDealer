using CarDealer.DataAccess.Context;
using CarDealer.DataAccess.Model.Repositories.Interfaces;
using CarDealer.DataAccess.Model.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.DataAccess.Model.Repositories
{
    public class DealerRepository : Repository<Dealer>, IDealerRepository
    {
        private readonly CarDealerContext _context;
        public DealerRepository(CarDealerContext context) : base(context)
        {
            _context = context;
        }

        protected override Dealer CreateEntity(int id)
        {
            return new Dealer { Id = id };
        }
 
    }
}
