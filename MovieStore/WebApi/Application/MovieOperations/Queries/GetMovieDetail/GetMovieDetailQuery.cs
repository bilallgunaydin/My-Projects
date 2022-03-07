using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movie=_dbContext.Movies
                                .Include(m=>m.MovieGenre)
                                .Include(m=>m.Director)
                                .Include(m=>m.MovieActors)
                                .ThenInclude(ma=>ma.Actor)
                                .SingleOrDefault(x=>x.Id==Id && x.IsPassive==false);
            if(movie is null) 
            throw new Exception("Film bulunamadı!");

            MovieDetailViewModel vm=_mapper.Map<MovieDetailViewModel>(movie);
            return vm;
        }

    }

    public class MovieDetailViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MovieGenre { get; set; }
        public string Director { get; set; }
        public int Price { get; set; }  
        public List<MovieActor> Actors { get; set; }
        public class MovieActor
        {
            public int Id { get; set; }
            public string FullName { get; set; }
        }
    }
}