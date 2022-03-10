using WebApiBook.Models;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Services
{
    public class ParagraphService : IParagraphService
    {
        private readonly INumberOfUniqueWords _numberOfUniqueWordsRepo;
        private readonly IUniqueWord _uniqueWordsRepo;
        private readonly IWatchlist _watchlistRepo;

        public ParagraphService(INumberOfUniqueWords numberOfUniqueWords,IUniqueWord uniqueWord, IWatchlist watchlist)
        {
            _numberOfUniqueWordsRepo = numberOfUniqueWords;
            _uniqueWordsRepo = uniqueWord;
            _watchlistRepo = watchlist;
        }

        public ParagraphResponse GetNumberOfUniqueWords(ParagraphRequest paragraph)
        {
            IEnumerable<string> allWords = paragraph.Paragraph.Split(' ');
            
            //True unique words
            //IEnumerable<string> uniqueWords = allWords.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key);
            
            //Remove duplicates "fake unique"
            IEnumerable<string> uniqueWords = allWords.Distinct().ToList();
            var count = uniqueWords.Count();
            int uniqueWordId = _numberOfUniqueWordsRepo.AddNumberOfUniqueWords(new NumberOfUniqueWord { NumOfUniqueWords = count });


            foreach(var word in uniqueWords)
            {
                _uniqueWordsRepo.AddUniqueWord(new UniqueWord { NumberOfUniqueWordsId = uniqueWordId, Word = word });
            }

            List<string> words = uniqueWords.Intersect(_watchlistRepo.GetWatchlist().Select(e => e.Word)).ToList();

            return new ParagraphResponse { Count = count, UniqueWords = words };
        }


    }
}
