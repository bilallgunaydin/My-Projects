using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{  
    public interface IMovieStoreDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Actor> Actors {get;set;}
        DbSet<Director> Directors {get;set;}
        DbSet<Genre> Genres { get ; set ;}
        DbSet<FavoriteMovie> FavoriteMovies { get; set;}
        DbSet<MovieActor> MoviesActors { get; set;}
        int SaveChanges();
    }
}
