using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;


namespace Commerce.Models
{
    public class CustomersDbcontext :DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public CustomersDbcontext(DbContextOptions<CustomersDbcontext> options) : base(options) { }
    }

}
