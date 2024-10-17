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

        public async Task Create(Author author)
        {
            _ctx.Authors.Add(author);
            await _ctx.SaveChangesAsync();
        }
    }
}
