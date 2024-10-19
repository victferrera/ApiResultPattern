using ApiResultPattern.DTO;
using ApiResultPattern.Models;

namespace ApiResultPattern.Repository
{
    public interface IBookRepository
    {
        Task Create(BookDTO book);
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
