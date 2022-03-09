namespace BookApi.Models
{
    public class WatchlistWord
    {
        public int Id { get; set; }
        public int UniqueWordsId { get; set; }
        public string Word { get; set; }
        public UniqueWord UniqueWord {get;set;}
    }
}
