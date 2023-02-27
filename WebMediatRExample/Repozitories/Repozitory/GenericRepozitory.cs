using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;
using WebMediatRExample.Data;
using WebMediatRExample.Repozitories.IRepozitory;

namespace WebMediatRExample.Repozitories.Repozitory
{
    public class GenericRepozitory<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        public GenericRepozitory(ApplicationDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            var x = await SaveAsync();
            if (x is 0) return null;
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter=null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
             _dbSet.Remove(entity);
            var x = await SaveAsync();
            if (x is 0) return false;
            return true;
        }

        public async Task<int> SaveAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
             _dbSet.Update(entity);
            var x= await SaveAsync();
            if (x is 0) return null;
            return entity;
        }
    }
}
