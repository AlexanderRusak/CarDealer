﻿

using CarDealer.DataAccess.Context;
using CarDealer.DataAccess.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.DataAccess.Model.Repositories.Interfaces.Base
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {

        public readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T item)
        {
            var result = await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(T item)
        {
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = CreateEntity(id);
            _context.Set<T>().Attach(entity);
            await DeleteAsync(entity);
        }

        public async Task<ICollection<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            var result = await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id);
            result ??= CreateEntity(0);
            return result;
        }

        public async Task UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync(true);
        }

        protected abstract T CreateEntity(int id);
    }
}
