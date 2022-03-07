using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public int OrderId { get; set; }
        public UpdateOrderViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;

        public UpdateOrderCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var order=_dbContext.Orders.SingleOrDefault(o => o.Id == OrderId);
            if (order is null)
                throw new InvalidOperationException("Sipariş bulunamadı!");
            order.CustomerId=Model.CustomerId !=default? order.CustomerId:Model.CustomerId;
            order.MovieId=Model.MovieId !=default? order.MovieId:Model.MovieId;
            order.Price=Model.Price !=default? order.Price:Model.Price;

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

    }

    public class UpdateOrderViewModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public int Price { get; set; }
    }
}