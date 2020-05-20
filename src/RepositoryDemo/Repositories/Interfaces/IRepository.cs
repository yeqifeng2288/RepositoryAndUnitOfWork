using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryDemo.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> FindAsync(object key);

        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
