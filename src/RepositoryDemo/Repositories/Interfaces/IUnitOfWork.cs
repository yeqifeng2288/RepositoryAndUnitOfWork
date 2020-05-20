using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RepositoryDemo.Repositories
{
    public interface IUnitOfWork<TDbContent> where TDbContent : DbContext
    {
        /// <summary>
        /// 获得IRepository。
        /// </summary>
        /// <typeparam name="TEntity">实体。</typeparam>
        /// <param name="isCustomRepository">是否自定义仓储，如果是，将从ServiceProvider获得。</param>
        /// <returns>返回IRepository。</returns>
        IRepository<TEntity> GetRepository<TEntity>(bool isCustomRepository = false) where TEntity : class;

        /// <summary>
        /// 提交。
        /// </summary>
        /// <returns>修改数量。</returns>
        Task<int> Commit();
    }
}