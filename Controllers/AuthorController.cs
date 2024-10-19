﻿using ApiResultPattern.DTO;
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
        public async Task NewAuthor(AuthorDTO author)
        {
            await _repo.Create(author);
        }
    }
}
