using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQuery(IMovieStoreDbContext dbContext, IMapper mapper )
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<GenresViewModel> Handle()
        {
            var genres=_dbContext.Genres.Include(genre=> genre.Movies)
                                        .OrderBy(genre=> genre).Where(genre=> genre.IsPassive==false);
            List<GenresViewModel> vm=_mapper.Map<List<GenresViewModel>>(genres);
            return vm;
        }
    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public List<GenreMovieVM> Movies { get; set; }
        public class GenreMovieVM
        {
            public int Id { get; set; }
            public string MovieName { get; set; }
        }
    }
}