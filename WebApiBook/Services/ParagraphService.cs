using WebApiBook.Models;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Services
{
    public class ParagraphService : IParagraphService
    {
        private readonly IUniqueWord _uniqueWordRepo;
        private readonly IWatchlistWord _watchlistWordRepo;
        private readonly ITestWord _TestWordRepo;

        public ParagraphService(IUniqueWord uniqueWord,IWatchlistWord watchlistWord, ITestWord TestWord)
        {
            _uniqueWordRepo = uniqueWord;
            _watchlistWordRepo = watchlistWord;
            _TestWordRepo = TestWord;
        }

        public ParagraphResponse GetNumberOfUniqueWords(ParagraphRequest paragraph)
        {
            IEnumerable<string> allWords = paragraph.Paragraph.Split(' ');
            IEnumerable<string> uniqueWords = allWords.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key);
            var count = uniqueWords.Count();
            int uniqueWordId = _uniqueWordRepo.AddUniqueWord(new UniqueWord { NumberOfUniqueWords = count });


            foreach(var word in uniqueWords)
            {
                _watchlistWordRepo.AddWatchlistWord(new WatchlistWord { UniqueWordId = uniqueWordId, Word = word });
            }

            List<string> words = uniqueWords.Intersect(_TestWordRepo.GetAllTestWords().Select(e => e.Word)).ToList();

            return new ParagraphResponse { Count = count, UniqueWords = words };
        }


    }
}
