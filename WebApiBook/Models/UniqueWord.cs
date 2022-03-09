namespace WebApiBook.Models
{
    public class UniqueWord
    {
        public int Id { get; set; }
        public int NumberOfUniqueWords { get; set; }
        public IEnumerable<WatchlistWord> WatchlistWords { get; set; }
    }
}
