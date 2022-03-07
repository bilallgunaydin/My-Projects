using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    { 
        protected static void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context= new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                
                List<Movie> moviesList = new List<Movie>()
                {
                    new Movie()
                    {
                        MovieName="Esaretin Bedeli", 
                        ReleaseDate=new DateTime(1994,01,01), 
                        Price=10, 
                        MovieGenreID=1, 
                        DirectorID=1,
                    },

                    new Movie()
                    {
                        MovieName="Baba", 
                        ReleaseDate=new DateTime(1973,10,10), 
                        Price=15, 
                        MovieGenreID=1,
                        DirectorID=2,
                    }
                };

                List<Actor> actorList= new List<Actor>()
                {
                    new Actor(){FirstName="Tim",LastName="Robbins"},
                    new Actor(){FirstName="Morgan",LastName="Freeman"},
                    new Actor(){FirstName="Marlon",LastName="Brando"},
                    new Actor(){FirstName="Al",LastName="Pacino"}
                };

                List<Director> directorList =new List<Director>()
                {
                    new Director() {FirstName="Frank",LastName="DaraBont"},
                    new Director() {FirstName="Francis Ford",LastName="Coppola"},
                    
                };

                List<MovieActor> movieActorList = new List<MovieActor>()
                {
                    new MovieActor() {MovieID=1,ActorID=1},
                    new MovieActor() {MovieID=1,ActorID=2},
                    new MovieActor() {MovieID=2,ActorID=3},
                    new MovieActor() {MovieID=2,ActorID=4},
                };
                List<Customer> customerList= new List<Customer>
                {
                    new Customer()
                    {
                        FirstName="John",
                        LastName="Doe",
                        Email="Johndoe@gmail.com",
                        Password="John123"
                    },

                    new Customer()
                    {
                        FirstName="Jane",
                        LastName="Doe",
                        Email="Janedoe@gmail.com",
                        Password="Jane123"
                    }
                };

                List<Order> orderList= new List<Order>
                {
                    new Order()
                    {
                        MovieId=1,
                        BuyingDate=new DateTime(2020,01,01),
                        CustomerId=1,
                        Price=10
                    },

                    new Order()
                    {
                        MovieId=2,
                        BuyingDate=new DateTime(2020,01,02),
                        CustomerId=2,
                        Price=15
                    }
                };

                List<FavoriteMovie> favoriteMoviesList = new List<FavoriteMovie>
                {
                    new FavoriteMovie()
                    {
                        MovieId=1,
                        CustomerId=1
                    },

                    new FavoriteMovie()
                    {
                        MovieId=2,
                        CustomerId=1
                    },
                    new FavoriteMovie()
                    {
                        MovieId=1,
                        CustomerId=2
                    },

                    new FavoriteMovie()
                    {
                        MovieId=2,
                        CustomerId=2
                    }
                };

                context.Genres.AddRange(
                    new Genre { GenreName = "Dram" },
                    new Genre { GenreName = "Aksiyon" },
                    new Genre { GenreName = "Komedi" },
                    new Genre { GenreName = "Korku" },
                    new Genre { GenreName = "Romantik" },
                    new Genre { GenreName = "Bilim-Kurgu" }
                );
                if(context.Movies.Any()|| context.Actors.Any()|| context.Directors.Any()|| context.Customers.Any()|| context.Orders.Any()|| context.FavoriteMovies.Any())
                return;


                 context.Directors.AddRange(directorList);
                 context.Movies.AddRange(moviesList);
                 context.Actors.AddRange(actorList);
                 context.MoviesActors.AddRange(movieActorList);
                 context.FavoriteMovies.AddRange(favoriteMoviesList);
                 context.Orders.AddRange(orderList);
                 context.Customers.AddRange(customerList);
                 context.SaveChanges();
            }
                
        }
    }
}