using ApiResultPattern.Application;
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
        public async Task<IActionResult> NewBook(BookDTO book)
        {
            var result = await _repo.Create(book);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(BookResponse.Create(result.Data));
        }

        [HttpGet("allbooks")]
        public async Task<IActionResult> AllBooks()
        {
            var result =  await _repo.GetAllBooks();

            return Ok(BookResponse.Create(result.Data));
        }

        [HttpGet("bookbyid/{id}")]
        public async Task<IActionResult> BookById(int id)
        {
            var book = await _repo.GetBookById(id);

            if (book == null)
                return NoContent();
            return Ok(book);
        }
    }
}
