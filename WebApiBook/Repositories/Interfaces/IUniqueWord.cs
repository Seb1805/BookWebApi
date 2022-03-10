using WebApiBook.Models;

namespace WebApiBook.Repositories.Interfaces
{
    public interface IUniqueWord
    {
        public void AddUniqueWord(UniqueWord word);

        public IEnumerable<UniqueWord> GetWords();
    }
}
