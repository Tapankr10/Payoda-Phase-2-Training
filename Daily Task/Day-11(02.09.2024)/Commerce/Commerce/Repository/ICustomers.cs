using Commerce.Models;

namespace Commerce.Repository
{
    public interface ICustomers
    {
        IEnumerable<Customers> GetCustomers();

        Customers GetCustomerById(int id);

        void AddCustomer(Customers customer);

        void UpdateCustomer(Customers customer);

        void DeleteCustomer(int id, Customers customer);

    }
}
