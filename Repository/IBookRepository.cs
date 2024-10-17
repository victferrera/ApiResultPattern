using ApiResultPattern.Models;

namespace ApiResultPattern.Repository
{
    public interface IBookRepository
    {
        Task Create(Book book);
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
