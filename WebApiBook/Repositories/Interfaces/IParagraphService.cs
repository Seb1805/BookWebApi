using WebApiBook.Models;

namespace WebApiBook.Repositories.Interfaces
{
    public interface IParagraphService
    {
        public int GetNumberOfUniqueWords(ParagraphRequest paragraph);
    }
}
