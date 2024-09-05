namespace Apiproject.Model
{
    public class Book
    {

        public int BookId { get; set; }
        public  string Title { get; set; }
        public int Price { get; set; }
        public ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
