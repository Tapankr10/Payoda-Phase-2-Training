namespace Apiproject.Model
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
