using ApiResultPattern.Application;
using ApiResultPattern.DTO;
using ApiResultPattern.Models;

namespace ApiResultPattern.Repository
{
    public interface IAuthorRepository
    {
        Task<Result<Author>> Create(AuthorDTO author);
    }
}
