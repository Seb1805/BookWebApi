using BookApi.Models;
using BookApi.Repositories.Interfaces;
using WebApiBook.Data;

namespace WebApiBook.Repositories
{
    public class UniqueWordRepo : IUniqueWord
    {
        private readonly BookContext _context;

        public UniqueWordRepo(BookContext context)
        {
            _context = context;
        }
        public int AddUniqueWord(UniqueWord word)
        {
            _context.UniqueWords.Add(word);
            _context.SaveChanges();
            return word.Id;
        }
    }
}
