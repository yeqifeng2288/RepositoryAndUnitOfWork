using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryDemo.Repositories
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext>, IDisposable where TDbContext : DbContext
    {
        private readonly DbContext _dbContext;

        private readonly Lazy<Dictionary<int, object>> _repositoryContainer;
        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositoryContainer = new Lazy<Dictionary<int, object>>();
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool isCustomRepository = false) where TEntity : class
        {
            if (isCustomRepository)
            {
                return _dbContext.GetService<IRepository<TEntity>>();
            }
            else
            {
                var name = typeof(TEntity).FullName.GetHashCode();
                if (!_repositoryContainer.Value.ContainsKey(name))
                {
                    _repositoryContainer.Value.Add(name, new Repository<TEntity>(_dbContext));
                }

                return _repositoryContainer.Value[name] as IRepository<TEntity>;
            }
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {
                _dbContext.Dispose();
            }
        }

        #endregion
    }
}
