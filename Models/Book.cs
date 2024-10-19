namespace ApiResultPattern.Models
{
    public class Book : BaseEntity
    {
        public Book(string name, DateTime releaseDate, int authorId)
        {
            Name = name;
            ReleaseDate = releaseDate;
            AuthorId = authorId;
        }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Author Author { get; set; } = null!;
        public int AuthorId { get; set; }
    }
}
