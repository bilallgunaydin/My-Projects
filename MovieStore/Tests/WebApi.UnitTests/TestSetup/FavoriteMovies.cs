using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class FavoriteMovies
    {
        public static void AddFavoriteMovies(this MovieStoreDbContext context){
            List<FavoriteMovie> favoriteMoviesList = new List<FavoriteMovie>
                {
                    new FavoriteMovie(){ MovieId=1, CustomerId=1 }, 
                    new FavoriteMovie(){ MovieId=2, CustomerId=1 },
                    new FavoriteMovie(){ MovieId=1, CustomerId=2 },
                    new FavoriteMovie(){ MovieId=2, CustomerId=2 }
                };

            context.FavoriteMovies.AddRange(favoriteMoviesList);
        }
    }
}