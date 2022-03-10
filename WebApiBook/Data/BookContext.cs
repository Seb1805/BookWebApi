using WebApiBook.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiBook.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        public DbSet<NumberOfUniqueWord> NumberOfUniqueWords { get; set; }
        public DbSet<UniqueWord> UniqueWords { get; set; }
        public DbSet<Watchlist> Watchlist { get; set; }
    }
}
