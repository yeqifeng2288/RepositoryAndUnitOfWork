using RepositoryDemo.Models;

namespace RepositoryDemo.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        int Count();
    }
}