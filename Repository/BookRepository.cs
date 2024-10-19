using ApiResultPattern.DTO;
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

        public async Task Create(BookDTO book)
        {
            var existingBook = _ctx.Books.Where(x => x.Name == book.Name).FirstOrDefault();

            if (existingBook != null)
                throw new Exception("There is already a book with the same name.");

            Book newBook = new Book(book.Name, book.ReleaseData, book.AuthorId);

            _ctx.Books.Add(newBook);
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
