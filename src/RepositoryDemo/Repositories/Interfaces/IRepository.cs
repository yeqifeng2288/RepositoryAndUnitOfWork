using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryDemo.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> FindAsync(object key);

        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

    }
}
