namespace WebApiBook.Models
{
    public class WatchlistWord
    {
        public int Id { get; set; }
        public int UniqueWordId { get; set; }
        public string Word { get; set; }
        public UniqueWord UniqueWord {get;set;}
    }
}
