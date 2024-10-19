using ApiResultPattern.Application;
using ApiResultPattern.DTO;
using ApiResultPattern.Models;

namespace ApiResultPattern.Repository
{
    public interface IBookRepository
    {
        Task<Result<Book>> Create(BookDTO book);
        Task<Result<Book>> GetBookById(int id);
        Task<Result<IEnumerable<Book>>> GetAllBooks();
    }
}
