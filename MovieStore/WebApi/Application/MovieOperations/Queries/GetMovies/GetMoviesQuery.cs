using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList=_dbContext.Movies
            .Include(m=>m.MovieGenre)
            .Include(m=>m.Director)
            .Include(m=>m.MovieActors)
            .ThenInclude(ma=>ma.Actor)
            .OrderBy(x=>x.Id)
            .Where(x=>x.IsPassive==false);
            List<MoviesViewModel> vm=_mapper.Map<List<MoviesViewModel>>(movieList);
            
            return vm;
        }

    }
    public class MoviesViewModel
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