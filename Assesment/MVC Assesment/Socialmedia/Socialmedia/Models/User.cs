using System.ComponentModel.DataAnnotations;

namespace Socialmedia.Models
{
    public class User
    {
        [Key]
        public int uId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
