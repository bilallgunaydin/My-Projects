using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options= new DbContextOptionsBuilder<MovieStoreDbContext>()
                .UseInMemoryDatabase(databaseName: "MovieStoreTestDB")
                .Options;
            Context = new MovieStoreDbContext(options);
            Context.AddMovies();
            Context.AddGenres();
            Context.AddActors();
            Context.AddDirectors();
            Context.AddMovieActors();
            Context.AddOrders();
            Context.AddFavoriteMovies();
            Context.AddCustomers();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }).CreateMapper();
        }
    }
}