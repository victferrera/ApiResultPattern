using ApiResultPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiResultPattern.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly Database.AppContext _ctx;
        public BookRepository(Database.AppContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(Book book)
        {
            _ctx.Books.Add(book);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _ctx.Books.Include(p => p.Author).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _ctx.Books.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
