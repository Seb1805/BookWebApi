using BookApi.Models;
using WebApiBook.Data;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Repositories
{
    public class WatchlistWordRepo : IWatchlistWord
    {
        private readonly BookContext _context;

        public WatchlistWordRepo(BookContext context)
        {
            _context = context;
        }
        public void AddWatchlistWord(WatchlistWord word)
        {
            throw new NotImplementedException();
        }
    }
}
