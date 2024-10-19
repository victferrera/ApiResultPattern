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

        public async Task Create(AuthorDTO author)
        {
            var existingAuthor = _ctx.Authors.Where(x => x.Name == author.Name).FirstOrDefault();

            if (existingAuthor != null)
                throw new Exception("There is already an author with the same name");

            Author newAuthor = new Author(author.Name);

            _ctx.Authors.Add(newAuthor);
            await _ctx.SaveChangesAsync();
        }
    }
}
