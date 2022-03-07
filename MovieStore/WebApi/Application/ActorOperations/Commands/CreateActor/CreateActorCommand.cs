using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorCommandModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor=_dbContext.Actors.SingleOrDefault(
                        actor => actor.FirstName.ToLower() == Model.FirstName.ToLower() 
                        && actor.LastName.ToLower() == Model.LastName.ToLower());
            if (actor is not null)
                throw new InvalidOperationException("Bu aktör zaten var!");

            List<Movie> movieList= new List<Movie>();
            for (int i = 0; i < Model.Movies.Count; i++)
                movieList.AddRange(_dbContext.Movies.Where(x=> x.Id==Model.Movies[i] && x.IsPassive==false).ToList());
            
            if(movieList.Count!=Model.Movies.Count)
            throw new InvalidOperationException("Girdiğiniz filmler bulunamadı.");

            actor=_mapper.Map<Actor>(Model);
            _dbContext.Actors.Add(actor);

            List<CreateActorMovieViewModel> createMovieActorViewModel
            = new List<CreateActorMovieViewModel>();
            foreach (var item in movieList)
            {
                createMovieActorViewModel.Add(
                new CreateActorMovieViewModel
                {ActorID=actor.Id, MovieID=item.Id});
            }   
            var MovieActorViewModel=_mapper.Map<List<MovieActor>>(createMovieActorViewModel);
            _dbContext.MoviesActors.AddRange(MovieActorViewModel);
            _dbContext.SaveChanges();

        }
    }

    public class CreateActorCommandModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Movies { get; set; }
    }

    public class CreateActorMovieViewModel
    {
        public int MovieID { get; set; }
        public int ActorID { get; set; }
    }

}