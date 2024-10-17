namespace ApiResultPattern.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Author? Author { get; set; }
        public int AuthorId { get; set; }
    }
}
