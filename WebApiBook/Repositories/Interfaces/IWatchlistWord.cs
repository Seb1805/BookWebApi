using WebApiBook.Models;

namespace WebApiBook.Repositories.Interfaces
{
    public interface IWatchlistWord
    {
        public void AddWatchlistWord(WatchlistWord word);

        public IEnumerable<WatchlistWord> GetWords();
    }
}
