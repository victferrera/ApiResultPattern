using ApiResultPattern.Models;

namespace ApiResultPattern.Repository
{
    public interface IAuthorRepository
    {
        Task Create(Author author);
    }
}
