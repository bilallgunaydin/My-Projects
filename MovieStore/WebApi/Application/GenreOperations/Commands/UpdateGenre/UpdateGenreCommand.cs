using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateGenreCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre=_dbContext.Genres.SingleOrDefault(genre=> genre.Id==GenreId);
            if(genre is null)
                throw new InvalidOperationException("Film türü bulunamadı.");
            genre.GenreName = Model.GenreName == default ? genre.GenreName : Model.GenreName;
            genre.IsPassive = Model.IsPassive == default ? genre.IsPassive : Model.IsPassive;
            _dbContext.Genres.Update(genre);
            _dbContext.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string GenreName { get; set; }
        public bool IsPassive { get; set; }  
    }
}