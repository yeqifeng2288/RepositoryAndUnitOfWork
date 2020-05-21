using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryDemo.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> contextOptions) : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Book>()
                .HasData(
                new Book
                {
                    Id = 1,
                    Title = "书一"
                },
                new Book
                {
                    Id = 2,
                    Title = "书二"
                },
                new Book
                {
                    Id = 3,
                    Title = "书三"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
