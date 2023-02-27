using System.Linq.Expressions;

namespace WebMediatRExample.Repozitories.IRepozitory
{
    public interface IGenericRepository<TEntity>where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter= null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> RemoveAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<int> SaveAsync();
    }
}
