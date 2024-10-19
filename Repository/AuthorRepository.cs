using ApiResultPattern.Application;
using ApiResultPattern.DTO;
using ApiResultPattern.Models;

namespace ApiResultPattern.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Database.AppContext _ctx;

        public AuthorRepository(Database.AppContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Result<Author>> Create(AuthorDTO author)
        {
            var existingAuthor = _ctx.Authors.Where(x => x.Name == author.Name).FirstOrDefault();

            if (existingAuthor != null)
                return Result<Author>.Failure(AuthorErrors.AuthorAlreadyExists);

            Author newAuthor = new Author(author.Name);

            _ctx.Authors.Add(newAuthor);
            await _ctx.SaveChangesAsync();

            return Result<Author>.Success(newAuthor);
        }
    }
}
