using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{   
    public class MovieStoreDbContext:DbContext,IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext>options):base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Actor> Actors {get;set;}
        public DbSet<Director> Directors {get;set;}
        public DbSet<Genre> Genres { get ; set ;}
        public DbSet<FavoriteMovie> FavoriteMovies { get; set;}
        public DbSet<MovieActor> MoviesActors { get; set;}
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                        .HasKey(ma => new { ma.MovieID, ma.ActorID});
            modelBuilder.Entity<MovieActor>()
                        .HasOne(m=> m.Movie)
                        .WithMany(ma=> ma.MovieActors)
                        .HasForeignKey(m=> m.MovieID);
            modelBuilder.Entity<MovieActor>()
                        .HasOne(a=> a.Actor)
                        .WithMany(ma=> ma.MovieActors)
                        .HasForeignKey(a=> a.ActorID);
        }
    } 
    
}