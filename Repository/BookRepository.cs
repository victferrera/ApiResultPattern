using ApiResultPattern.Application;
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

        public async Task<Result<Book>> Create(BookDTO book)
        {
            var existingBook = _ctx.Books.Where(x => x.Name == book.Name).FirstOrDefault();

            if (existingBook != null)
                return Result<Book>.Failure(BookErrors.BookAlreadyExists);

            var author = _ctx.Authors.Where(x => x.Id == book.AuthorId).FirstOrDefault();

            if (author == null)
                return Result<Book>.Failure(AuthorErrors.AuthorNotExist);

            Book newBook = new Book(book.Name, book.ReleaseData, book.AuthorId);

            _ctx.Books.Add(newBook);
            await _ctx.SaveChangesAsync();

            return Result<Book>.Success(newBook);
        }

        public async Task<Result<IEnumerable<Book>>> GetAllBooks()
        {
            var books =  await _ctx.Books.Include(p => p.Author).ToListAsync();

            return Result<IEnumerable<Book>>.Success(books);
        }

        public async Task<Result<Book>> GetBookById(int id)
        {
            var book = await _ctx.Books.Where(p => p.Id == id).FirstOrDefaultAsync();

            return Result<Book>.Success(book);
        }
    }
}
