namespace ApiResultPattern.Models
{
    public class Author : BaseEntity
    {
        public Author(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
