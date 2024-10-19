namespace ApiResultPattern.Application
{
    public sealed record Error(string Code, string Description)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }

    public static class BookErrors
    {
        public static readonly Error BookAlreadyExists = new Error(
            "Book.AlreadyExists", "There is already a book with the same name.");
    }

    public static class AuthorErrors
    {
        public static readonly Error AuthorAlreadyExists = new Error(
            "Author.AlreadyExists", "There is already an author with the same name.");

        public static readonly Error AuthorNotExist = new Error(
            "Author.NotExist", "There isn't an author with the provided ID.");
    }
}
