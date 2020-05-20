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
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
