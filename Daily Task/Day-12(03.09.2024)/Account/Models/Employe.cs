using System.ComponentModel.DataAnnotations;

namespace Account.Models
{
    public class Employe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
    }
}
