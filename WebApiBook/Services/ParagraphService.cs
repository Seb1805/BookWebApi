using WebApiBook.Models;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Services
{
    public class ParagraphService : IParagraphService
    {
        public int GetNumberOfUniqueWords(ParagraphRequest paragraph)
        {
            IEnumerable<string> allWords = paragraph.Paragraph.Split(' ');
            IEnumerable<string> uniqueWords = allWords.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key);
            return uniqueWords.Count();
        }
    }
}
