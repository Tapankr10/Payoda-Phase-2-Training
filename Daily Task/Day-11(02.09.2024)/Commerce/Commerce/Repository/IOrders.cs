using Commerce.Models;

namespace Commerce.Repository
{
    public interface IOrders
    {
        IEnumerable<Orders> GetOrders();


        Orders GetOrdersById(int id);

       void AddOrders(Orders customer);

       void UpdateOrders(Orders customer);

        void DeleteOrders(int id, Orders customer);
    }
}
