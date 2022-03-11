using WebApiBook.Models;
using WebApiBook.Data;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Repositories
{
    public class UniqueWordsRepo : IUniqueWord
    {
        private readonly BookContext _context;

        public UniqueWordsRepo(BookContext context)
        {
            _context = context;
        }
        public void AddUniqueWord(UniqueWord word)
        {
            _context.Add(word);
            //Movied to seperate function to increase performence
            //_context.SaveChanges();
        }

        public IEnumerable<UniqueWord> GetWords()
        {
            return _context.UniqueWords;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
