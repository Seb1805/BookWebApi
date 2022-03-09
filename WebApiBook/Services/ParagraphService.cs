using WebApiBook.Models;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Services
{
    public class ParagraphService : IParagraphService
    {
        private readonly IUniqueWord _uniqueWordRepo;
        private readonly IWatchlistWord _watchlistWord;

        public ParagraphService(IUniqueWord uniqueWord,IWatchlistWord watchlistWord)
        {
            _uniqueWordRepo = uniqueWord;
            _watchlistWord = watchlistWord;
        }

        public int GetNumberOfUniqueWords(ParagraphRequest paragraph)
        {
            IEnumerable<string> allWords = paragraph.Paragraph.Split(' ');
            IEnumerable<string> uniqueWords = allWords.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key);
            var count = uniqueWords.Count();
            int uniqueWordId = _uniqueWordRepo.AddUniqueWord(new UniqueWord { NumberOfUniqueWords = count });
            
            foreach(var word in uniqueWords)
            {
                _watchlistWord.AddWatchlistWord(new WatchlistWord { UniqueWordId = uniqueWordId, Word = word });
            }

            return count;
        }


    }
}
