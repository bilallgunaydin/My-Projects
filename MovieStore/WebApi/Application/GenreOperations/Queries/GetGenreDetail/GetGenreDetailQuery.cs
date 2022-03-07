using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(IMovieStoreDbContext dbContext,IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public GenreViewModel Handle()
        {
            var genre = _dbContext.Genres.Include(genre => genre.Movies)
                                         .OrderBy(genre => genre.Id).Where(genre => genre.IsPassive == false)
                                         .SingleOrDefault(genre => genre.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Film türü bulunamadı.");

            GenreViewModel vm = _mapper.Map<GenreViewModel>(genre);
            return vm;
        }
    }

    public class GenreViewModel
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