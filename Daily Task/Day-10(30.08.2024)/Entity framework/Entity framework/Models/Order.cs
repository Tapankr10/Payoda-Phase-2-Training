using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework.Models
{
    public class Order
    {
        public int orderId { get; set; }

        public string ? ProductName { get; set; }

        public DateTime? OrderDate { get; set; }
      
        public int custID { get; set; }
        [ForeignKey("custID")]
        public Customer? Customer { get; set; }


    }
}
