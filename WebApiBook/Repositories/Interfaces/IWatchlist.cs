using WebApiBook.Models;

namespace WebApiBook.Repositories.Interfaces
{
    public interface IWatchlist
    {
        public IEnumerable<Watchlist> GetWatchlist();
    }
}
