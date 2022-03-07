using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(
                        director => director.Id == DirectorId);
            if (director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı.");

            List<Movie> movies = _dbContext.Movies.Where(movie => movie.DirectorID==DirectorId).ToList();
            if (movies.Count>0)
                throw new InvalidOperationException("Önce, yönetmene ait filmler silinmeli.");
            
             director.IsPassive = true;
            _dbContext.Directors.Update(director);
            _dbContext.SaveChanges();
        }
    }
}