using System.ComponentModel.DataAnnotations;

namespace Commerce.Models
{
    public class Customers
    {


        [Key]

        public int custID { get; set; }
        public String custName { get; set; }

        public int custage { get; set; }

        public string custcity { get; set; }

        public List<Orders> orders { get; set; }
    }
}
