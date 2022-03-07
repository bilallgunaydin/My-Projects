using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public int actorID { get; set; }
        public UpdateActorViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(
                        actor => actor.Id == actorID);
            if (actor is null)
                throw new InvalidOperationException("Aktör bulunamadı.");
            actor.FirstName = Model.FirstName == default ? actor.FirstName : Model.FirstName;
            actor.LastName = Model.LastName == default ? actor.LastName : Model.LastName;
            actor.IsPassive = Model.IsPassive == default ? actor.IsPassive : Model.IsPassive;
            _dbContext.Actors.Update(actor);
            _dbContext.SaveChanges();
        }
    }

    public class UpdateActorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPassive { get; set; }=false;
    }
}