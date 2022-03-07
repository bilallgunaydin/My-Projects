using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie=_dbContext.Movies.SingleOrDefault(
                        movie=> movie.MovieName.ToLower()==Model.MovieName.ToLower());
            var director=_dbContext.Directors.SingleOrDefault(director=> director.Id==Model.DirectorID);
            var genre=_dbContext.Genres.SingleOrDefault(genre=> genre.Id==Model.MovieGenreID);                     
            if(movie is not null)
            throw new InvalidOperationException("Film zaten mevcut.");
            if(director is null)
            throw new InvalidOperationException("Girdiğiniz yönetmen bulunamadı.");
            if(genre is null)
            throw new InvalidOperationException("Girdiğiniz film türü bulunamadı.");

            
            List<Actor> actorList= new List<Actor>();
            for (int i = 0; i < Model.Actors.Count; i++)
            actorList.AddRange(_dbContext.Actors.Where(x=> x.Id==Model.Actors[i] && x.IsPassive==false).ToList());
            
            if(actorList.Count!=Model.Actors.Count)
            throw new InvalidOperationException("Girdiğiniz oyuncular bulunamadı.");
            
            movie=_mapper.Map<Movie>(Model);
            _dbContext.Movies.Add(movie);
            List<CreateMovieActorViewModel> createMovieActorViewModel
            = new List<CreateMovieActorViewModel>();
            foreach (var item in actorList)
            {
                createMovieActorViewModel.Add(
                new CreateMovieActorViewModel
                {MovieID=movie.Id, ActorID=item.Id});
            }
            var MovieActorViewModel=_mapper.Map<List<MovieActor>>(createMovieActorViewModel);
            _dbContext.MoviesActors.AddRange(MovieActorViewModel);
            _dbContext.SaveChanges();
            
        }
    }

    public class CreateMovieModel
    {
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MovieGenreID { get; set; }
        public int DirectorID { get; set; }
        public int Price { get; set; }  
        public List<int> Actors { get; set; }
    }

    public class CreateMovieActorViewModel
    {
        public int MovieID { get; set; }
        public int ActorID { get; set; }
    }
}