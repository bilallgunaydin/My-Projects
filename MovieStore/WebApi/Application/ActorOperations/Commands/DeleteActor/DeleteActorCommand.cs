using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int actorID { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(
                        actor => actor.Id == actorID);
            if (actor is null)
                throw new InvalidOperationException("Aktör bulunamadı.");
            List<MovieActor> movieActor = _dbContext.MoviesActors.Where(x => x.ActorID == actorID).ToList();
            if(movieActor.Count>0)
                throw new InvalidOperationException("Aktörün filmleri önce silinmeli.");
            
            actor.IsPassive=true;
            _dbContext.Actors.Update(actor);
            _dbContext.SaveChanges();
        }
    }
}