using WebApiBook.Data;
using WebApiBook.Models;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Repositories
{
    public class WatchlistRepo : IWatchlist
    {
        private readonly BookContext _context;

        public WatchlistRepo(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Watchlist> GetWatchlist()
        {
            return _context.Watchlist;
        }
    }
}
