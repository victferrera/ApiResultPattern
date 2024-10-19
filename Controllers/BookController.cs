using ApiResultPattern.DTO;
using ApiResultPattern.Models;
using ApiResultPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiResultPattern.Controllers
{
    [ApiController]
    [Route("v1")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repo;
        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("newbook")]
        public async Task NewBook(BookDTO book)
        {
            await _repo.Create(book);
        }

        [HttpGet("allbooks")]
        public async Task<IEnumerable<Book>> AllBooks()
        {
            return await _repo.GetAllBooks();
        }

        [HttpGet("bookbyid/{id}")]
        public async Task<Book> BookById(int id)
        {
            return await _repo.GetBookById(id);
        }
    }
}
