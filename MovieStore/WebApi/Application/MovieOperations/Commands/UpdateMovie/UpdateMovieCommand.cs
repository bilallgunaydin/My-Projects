using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }

        public UpdateMovieViewModel Model {get; set;}

        private readonly IMovieStoreDbContext _dbContext;

        public UpdateMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(
                        movie => movie.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("Film bulunamadı.");
            movie.MovieName = Model.MovieName==default? movie.MovieName:Model.MovieName;
            movie.ReleaseDate=Model.ReleaseDate==default? movie.ReleaseDate:Model.ReleaseDate;
            movie.MovieGenreID=Model.MovieGenreID==default? movie.MovieGenreID:Model.MovieGenreID;
            movie.DirectorID=Model.DirectorID==default? movie.DirectorID:Model.DirectorID;
            movie.Price=Model.Price==default? movie.Price:Model.Price;
            movie.IsPassive=Model.IsPassive==default? movie.IsPassive:Model.IsPassive;

            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges();
        }
    }

    public class UpdateMovieViewModel
    {
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MovieGenreID { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }
        public bool IsPassive { get; set; }  
    }
}