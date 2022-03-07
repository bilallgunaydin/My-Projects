using AutoMapper;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.DBOperations;

namespace WebApi.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQuery
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrdersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<OrdersViewModel> Handle()
        {
            var orderMovie = _dbContext.Orders.Include(x => x.Movie).Where(x => x.CustomerId == CustomerId);
            if (orderMovie is null)
                throw new InvalidOperationException("Satın almalar bulunamadı!");

            List<OrdersViewModel> returnObj = _mapper.Map<List<OrdersViewModel>>(orderMovie);

            return returnObj;
        }
    }

    public class OrdersViewModel
    {
       public string Customer { get; set; }
       public string MovieName { get; set; }
       public DateTime BuyingDate { get; set; }
       public int Price { get; set; }

    }
}