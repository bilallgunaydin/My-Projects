using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteCustomerCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id==CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı.");

            List<Order> orders = _dbContext.Orders.Where(x => x.CustomerId == customer.Id).ToList();
            if(orders.Count>0)
                throw new InvalidOperationException("Önce müşteriye ait siparişler silinmeli.");
            
            customer.IsPassive=true;
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }
    }
}