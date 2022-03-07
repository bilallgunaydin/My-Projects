using System.Collections.Generic;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class MovieActors
    {
        public static void AddMovieActors(this MovieStoreDbContext context){
            List<MovieActor> movieActorList = new List<MovieActor>()
                {
                    new MovieActor() {MovieID=1,ActorID=1},
                    new MovieActor() {MovieID=1,ActorID=2},
                    new MovieActor() {MovieID=2,ActorID=3},
                    new MovieActor() {MovieID=2,ActorID=4},
                };
            context.MoviesActors.AddRange(movieActorList);
        }
    }
}