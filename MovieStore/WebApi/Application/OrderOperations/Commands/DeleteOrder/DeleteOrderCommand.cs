using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        public int OrderId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;

        public DeleteOrderCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(o => o.Id == OrderId);
            if (order is null)
                throw new InvalidOperationException("Sipariş bulunamadı!");
            
            var customer=_dbContext.Customers.Where(c=> c.Orders.Any(o=>o.Id==OrderId)).SingleOrDefault();
            if (customer is null)
                throw new InvalidOperationException("Siparişe ait kullanıcı bulunamadı!");

            customer.Orders.Remove(order);

            order.IsPassive=true;
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}