using System.ComponentModel.DataAnnotations;

namespace Entity_framework.Models
{
    public class Customer
    {

        [Key]

        public int custID {  get; set; }
        public String custName {  get; set; }

        public int custage {  get; set; }

        public string custcity { get; set; }

        public List<Order> orders { get; set; } 

    }
}
