using WebApiBook.Models;

namespace WebApiBook.Repositories.Interfaces
{
    public interface ITestWord
    {
        public IEnumerable<TestWord> GetAllTestWords();
    }
}
