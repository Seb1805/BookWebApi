namespace WebApiBook.Models
{
    public class ParagraphResponse
    {
            public int Count { get; set; }
            public IEnumerable<string> UniqueWords { get; set; }
    }
}
