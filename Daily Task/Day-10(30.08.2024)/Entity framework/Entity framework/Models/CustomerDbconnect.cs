using Microsoft.EntityFrameworkCore;

namespace Entity_framework.Models
{
    public class CustomerDbconnect:DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CustomerDbconnect(DbContextOptions<CustomerDbconnect> options) : base(options) { }
    }
}
