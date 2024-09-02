using System.ComponentModel.DataAnnotations.Schema;

namespace Commerce.Models
{
    public class Orders
    {

        public int orderId { get; set; }

        public string? ProductName { get; set; }

        public DateTime? OrderDate { get; set; }

        public int custID { get; set; }
        [ForeignKey("custID")]
        public Customers? Customer { get; set; }
    }
}
