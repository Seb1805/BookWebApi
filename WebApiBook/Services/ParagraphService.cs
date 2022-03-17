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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        public ParagraphResponse GetNumberOfUniqueWords(ParagraphRequest paragraph)
        {
            //Assume text has replaced quotes ""
            //TODO: RegExp
            IEnumerable<string> allWords = paragraph.Paragraph.Split(' ');

            //True unique words
            //IEnumerable<string> uniqueWords = allWords.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key);

            //Remove duplicates "fake unique
            IEnumerable<string> uniqueWords = allWords.Distinct();
            var count = uniqueWords.Count();
            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Test",ex);
            //}


            NumberOfUniqueWord numOfWords = new NumberOfUniqueWord();
            numOfWords.NumOfUniqueWords = count;
            int uniqueWordId = _numberOfUniqueWordsRepo.AddNumberOfUniqueWords(numOfWords);

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
 
            IEnumerable<string> words = uniqueWords.Intersect(_watchlistRepo.GetWatchlist().Select(e => e.Word));
            //List<string> words = _watchlistRepo.GetWatchlist().Select(e => e.Word).Intersect(uniqueWords).ToList();

            ParagraphResponse response = new ParagraphResponse();
            response.Count = count;
            response.UniqueWords = words;

            return response;
        }


    }
}
