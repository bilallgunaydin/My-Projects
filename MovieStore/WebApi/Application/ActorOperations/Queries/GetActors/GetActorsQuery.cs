using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using WebApi.DBOperations;

namespace WebApi.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }

        public List<ActorsViewModel> Handle()
        {
            var ActorList=_dbContext.Actors
            .Include(m=>m.MovieActors)
            .ThenInclude(ma=>ma.Movie)
            .OrderBy(x=>x.Id)
            .Where(x=>x.IsPassive==false);
            List<ActorsViewModel> vm=_mapper.Map<List<ActorsViewModel>>(ActorList);
            
            return vm;
        }
    }


    public class ActorsViewModel
    {
       public int Id { get; set; }
       public string FullName { get; set; }               
       public List<MovieActor> Movies { get; set; }
        public class MovieActor
        {
            public int Id { get; set; }
            public string MovieName { get; set; }
        }
    }
}