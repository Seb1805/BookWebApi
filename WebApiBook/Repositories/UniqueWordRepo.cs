using BookApi.Models;
using System.Data.SqlClient;
using WebApiBook.Data;

namespace BookApi.Repositories
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
