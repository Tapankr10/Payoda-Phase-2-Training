using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPaper.Model
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }

        // Foreign key property
        public int AuthorID { get; set; }

        public int Views { get; set; }

        // Navigation property
        [ForeignKey("AuthorID")] // Specifies that AuthorID is the foreign key
        public Author? Authors { get; set; }
    }
}
