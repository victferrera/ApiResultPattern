using ApiResultPattern.DTO;
using ApiResultPattern.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiResultPattern.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repo;

        public AuthorController(IAuthorRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("newauthor")]
        public async Task<IActionResult> NewAuthor(AuthorDTO author)
        {
            var result = await _repo.Create(author);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
