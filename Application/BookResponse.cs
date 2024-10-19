using ApiResultPattern.DTO;
using ApiResultPattern.Models;

namespace ApiResultPattern.Application
{
    public sealed record BookResponse(int id, string name, DateTime releaseData, string authorName, int authorId)
    {
        public static IEnumerable<BookResponse> Create(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                yield return new BookResponse(book.Id, book.Name, book.ReleaseDate, book.Author.Name, book.Author.Id);
            }
        }

        public static BookResponse Create(Book book)
        {
            return new BookResponse(book.Id, book.Name, book.ReleaseDate, book.Author.Name, book.AuthorId);
        }
    }
}
