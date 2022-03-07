using AutoMapper;
using WebApi.DBOperations;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery
    {
        public int OrderId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrderDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public OrderMovieDetailViewModel Handle()
        {
            var order = _dbContext.Orders.Include(x=>x.Customer).Include(x=>x.Movie).SingleOrDefault(x=>x.Id == OrderId && x.IsPassive == true);
            if(order is null)
                throw new InvalidOperationException("Sipariş bulunamadı!");

            OrderMovieDetailViewModel returnObj = _mapper.Map<OrderMovieDetailViewModel>(order);

            return returnObj;
        }
    }

    public class OrderMovieDetailViewModel
    {
        public string Customer { get; set; }
        public string MovieName { get; set; }
        public DateTime BuyingDate { get; set; }
        public int Price { get; set; }
    }
}