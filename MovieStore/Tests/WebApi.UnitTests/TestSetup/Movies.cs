using System;
using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context){
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
            context.Movies.AddRange(moviesList);
        }
    }
}