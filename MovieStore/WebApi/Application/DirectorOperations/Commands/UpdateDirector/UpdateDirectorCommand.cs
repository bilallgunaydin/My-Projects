using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorID { get; set; }
        public UpdateDirectorViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(director => director.Id == DirectorID);
            if (director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı.");
                
            director.FirstName = Model.FirstName == default ? director.FirstName : Model.FirstName;
            director.LastName = Model.LastName == default ? director.LastName : Model.LastName;
            director.IsPassive = Model.IsPassive == default ? director.IsPassive : Model.IsPassive;
            _dbContext.Directors.Update(director);
            _dbContext.SaveChanges();
        }
        
    }
    public class UpdateDirectorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPassive { get; set; }  
    }
}