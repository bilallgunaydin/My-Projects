using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        public DeleteGenreCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Film türü bulunamadı.");
            List<Movie> movies = _dbContext.Movies.Where(movie => movie.MovieGenreID == GenreId).ToList();
            if (movies.Count>0)
                throw new InvalidOperationException("Önce, film türüne ait filmler silinmeli.");
            
            genre.IsPassive = true;
            _dbContext.Genres.Update(genre);
            _dbContext.SaveChanges();
        }
    }
}