using Commerce.Models;
using Commerce.Repository;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Service
{
    public class OrdersService : IOrders
    {
        private readonly CustomersDbcontext _dbContext;

       

        public OrdersService(CustomersDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrders(Orders order)
        {
            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrders(int id, Orders order)
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public Orders GetOrdersById(int id)
        {
            return _dbContext.Orders.Include(c => c.Customer).FirstOrDefault(o => o.orderId == id);
        }

        public IEnumerable<Orders> GetOrders()
        {
            return _dbContext.Orders.Include(c => c.Customer).ToList();
        }

        public void UpdateOrders(Orders order)
        {
            _dbContext.Update(order);
        }
    }
}
