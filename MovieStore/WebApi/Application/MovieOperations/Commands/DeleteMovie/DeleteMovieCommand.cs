using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId {get; set;}
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(
                        movie => movie.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("Film bulunamadı.");
            List<MovieActor> movieActor = _dbContext.MoviesActors.Where(x => x.MovieID == MovieId).ToList();
            foreach (var item in movieActor)
            {
                if(item.MovieID==MovieId)
                _dbContext.MoviesActors.Remove(item);
            }
            movie.IsPassive=true;
            movie.MovieGenreID=0;
            movie.DirectorID=0;
            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges();
        }
    }
}