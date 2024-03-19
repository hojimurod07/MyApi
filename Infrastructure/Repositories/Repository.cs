

using Domain;
using Domain.Entities;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories
{
    public class Repository<T>(AppDbContext dbContext) : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext = dbContext;
        private readonly DbSet<T> _dbSet = dbContext.Set<T>();

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
