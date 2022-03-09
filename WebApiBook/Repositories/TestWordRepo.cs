using WebApiBook.Data;
using WebApiBook.Models;
using WebApiBook.Repositories.Interfaces;

namespace WebApiBook.Repositories
{
    public class TestWordRepo : ITestWord
    {
        private readonly BookContext _context;

        public TestWordRepo(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<TestWord> GetAllTestWords()
        {
            var list = _context.TestWordList.ToList();
            return list;
        }
    }
}
