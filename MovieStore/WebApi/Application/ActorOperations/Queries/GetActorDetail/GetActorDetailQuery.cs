using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetActorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

         public ActorDetailViewModel Handle()
        {
             var actor=_dbContext.Actors
            .Include(m=>m.MovieActors)
            .ThenInclude(ma=>ma.Movie)
            .SingleOrDefault(x=>x.Id==Id);
            if(actor is null) 
            throw new Exception("Aktör bulunamadı!");

            ActorDetailViewModel vm=_mapper.Map<ActorDetailViewModel>(actor);
            return vm;
        }

    }

    public class ActorDetailViewModel
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