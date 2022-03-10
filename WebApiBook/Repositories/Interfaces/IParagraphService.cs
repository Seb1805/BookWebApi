using WebApiBook.Models;

namespace WebApiBook.Repositories.Interfaces
{
    public interface IParagraphService
    {
        public ParagraphResponse GetNumberOfUniqueWords(ParagraphRequest paragraph);
    }
}
