using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPaper.Model
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public decimal CredibilityScore { get; set; }
        public string? Bio { get; set; }

        // Navigation property representing the articles written by the author
        public ICollection<Article>? Articles { get; set; }

    }
}
