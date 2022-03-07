using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CustomerDetailViewModel Handle()
        {
            var customer = _dbContext.Customers.Include(x => x.FavoriteMovies)
                                            .ThenInclude(cfg =>cfg.Movie)
                                            .Include(x => x.Orders)
                                            .ThenInclude(x => x.Movie).SingleOrDefault(c => c.Id == CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı!");
            CustomerDetailViewModel returnObj = _mapper.Map<CustomerDetailViewModel>(customer);
            return returnObj;
        }

    }

    public class CustomerDetailViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<OrdersMovie> Orders { get; set; }
        public List<CustomerFavoriteMovieVM> FavoriteMovies { get; set; }

        public struct OrdersMovie
        {
            public int Id { get; set; }
            public CustomerFavoriteMovieVM Movie { get; set; }
            public int PurchasedPrice { get; set; }
            public DateTime PurchasedDate { get; set; }
            public bool isPassive { get; set; }
        }

        public class CustomerFavoriteMovieVM
        {
            public int Id { get; set; }
            public string MovieName { get; set; }
            public int Price { get; set; }
        }
    }
}