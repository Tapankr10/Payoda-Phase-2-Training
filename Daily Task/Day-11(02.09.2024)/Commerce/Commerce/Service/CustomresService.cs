using Commerce.Models;
using Commerce.Repository;

namespace Commerce.Service
{
    public class CustomersService : ICustomers
    {
        private readonly CustomersDbcontext _dbContext;

        public CustomersService(CustomersDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomer(Customers customer)
        {
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
        }

        public void DeleteCustomer(int id, Customers customer)
        {
            _dbContext.Remove(customer);
            _dbContext.SaveChanges();
        }

        public Customers GetCustomerById(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer != null)
                return customer;
            return null;
        }

        public void UpdateCustomer(Customers customer)
        {
            _dbContext.Update(customer);
            _dbContext.SaveChanges();
        }

        IEnumerable<Customers> ICustomers.GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }
    }
}
