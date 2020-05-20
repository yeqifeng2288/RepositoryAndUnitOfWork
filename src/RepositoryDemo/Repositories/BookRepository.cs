using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Data;
using RepositoryDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryDemo.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly DbContext _dbContext;

        public BookRepository(BookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int Count()
        {
            return _dbContext.Set<Book>().Count();
        }
    }
}
