using CarDealer.DataAccess.Model.Base;

namespace CarDealer.DataAccess.Model.Repositories.Interfaces.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity item);
        Task DeleteAsync(TEntity item);
        Task DeleteAsync(int id);
        Task UpdateAsync(TEntity item);
        Task<ICollection<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);

    }
}
