using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socialmedia.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string ? Title { get; set; }
        public string ?Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? user { get; set; }

    }
}
