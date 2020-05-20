using Microsoft.AspNetCore.Mvc;
using RepositoryDemo.Data;
using RepositoryDemo.Models;
using RepositoryDemo.Repositories;
using System.Threading.Tasks;

namespace RepositoryDemo.Controllers
{
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _repository;
        private readonly IUnitOfWork<BookDbContext> _unitOfWork;

        public BookController(IUnitOfWork<BookDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Book>();
        }

        [HttpGet]
        public async Task<ActionResult<Book>> Get()
        {
            var book = await _repository.FindAsync(1);
            if (book == null)
            {
                await _repository.AddAsync(new Book { Id = 1, Title = "TestBook" });
                _ = await _unitOfWork.Commit();
            }

            return book;
        }
    }
}
