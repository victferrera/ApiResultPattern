using ApiResultPattern.DTO;

namespace ApiResultPattern.Repository
{
    public interface IAuthorRepository
    {
        Task Create(AuthorDTO author);
    }
}
