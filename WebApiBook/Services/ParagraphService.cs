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
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            IEnumerable<string> allWords = paragraph.Paragraph.Split(' ');

            //True unique words
            //IEnumerable<string> uniqueWords = allWords.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key);

            //Remove duplicates "fake unique"
            IEnumerable<string> uniqueWords = allWords.Distinct().ToList();

            var count = uniqueWords.Count();
            int uniqueWordId = _numberOfUniqueWordsRepo.AddNumberOfUniqueWords(new NumberOfUniqueWord { NumOfUniqueWords = count });




            foreach (var word in uniqueWords)
            {
                UniqueWord uniqueWord = new UniqueWord();
                uniqueWord.NumberOfUniqueWordsId = uniqueWordId;
                uniqueWord.Word = word;
                _uniqueWordsRepo.AddUniqueWord(uniqueWord);
                //_uniqueWordsRepo.AddUniqueWord(new UniqueWord { NumberOfUniqueWordsId = uniqueWordId, Word = word });
            }
            //Move savechanges outside the loop for increased perfomence
            _uniqueWordsRepo.SaveChanges();

            List<string> words = uniqueWords.Intersect(_watchlistRepo.GetWatchlist().Select(e => e.Word)).ToList();
            TimeSpan ts = watch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            watch.Stop();
            System.Diagnostics.Trace.WriteLine("RunTime " + elapsedTime);
            return new ParagraphResponse { Count = count, UniqueWords = words };
        }


    }
}
