using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiBook.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        public DbSet<UniqueWord> UniqueWords { get; set; }
        public DbSet<WatchlistWord> WatchlistWords { get; set; }
    }
}
