using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateFavoriteMovie
    {
        public CreateFavoriteMovieModel Model { get; set; }
        public string CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateFavoriteMovie(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(customer => customer.Email==CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı.");
            List<Movie> movieList= new List<Movie>();
            for (int i = 0; i < Model.Movies.Count; i++)
            movieList.AddRange(_dbContext.Movies.Where(x=> x.Id==Model.Movies[i] && x.IsPassive==false).ToList());
            
            if(movieList.Count!=Model.Movies.Count)
            throw new InvalidOperationException("Girdiğiniz filmler bulunamadı.");
            
            List<FavoriteMovie> favoriteMovies=new List<FavoriteMovie>();
            for (int i = 0; i < movieList.Count; i++)
            {
                FavoriteMovie favoriteMovie=new FavoriteMovie();
                favoriteMovie.CustomerId=customer.Id;
                favoriteMovie.MovieId=movieList[i].Id;
                favoriteMovies.Add(favoriteMovie);
            }
           
            customer.FavoriteMovies=favoriteMovies;
            _dbContext.Customers.Update(customer);
            _dbContext.FavoriteMovies.AddRange(favoriteMovies);
            _dbContext.SaveChanges();
            
        }
    }

    public class CreateFavoriteMovieModel
    {
        public List<int> Movies { get; set; }
    }
}