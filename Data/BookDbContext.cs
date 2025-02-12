using Microsoft.EntityFrameworkCore;
using BookProject.Models;

namespace BookProject.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}

