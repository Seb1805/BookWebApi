using WebApiBook.Models;
using WebApiBook.Repositories.Interfaces;
using WebApiBook.Data;
using WebApiBook.Models;

namespace WebApiBook.Repositories
{
    public class NumberOfUniqueWordRepo : INumberOfUniqueWords
    {
        private readonly BookContext _context;

        public NumberOfUniqueWordRepo(BookContext context)
        {
            _context = context;
        }

        public int AddNumberOfUniqueWords(NumberOfUniqueWord word)
        {
            _context.NumberOfUniqueWords.Add(word);
            _context.SaveChanges();
            return word.Id;
        }
    }
}
