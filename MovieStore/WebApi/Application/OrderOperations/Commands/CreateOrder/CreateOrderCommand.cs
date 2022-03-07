using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System;
using System.Linq;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateOrderCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var order = _mapper.Map<Order>(Model);
            order.BuyingDate = DateTime.Now;
            _dbContext.Orders.Add(order);
            var customer=_dbContext.Customers.SingleOrDefault(c => c.Id == Model.CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı!");
            customer.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
    
    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public int Price { get; set; }
    }
}