using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
       private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DirectorsViewModel> Handle()
        {
            var directors = _dbContext.Directors.Include(director => director.Movies)
                                                .OrderBy(director => director)
                                                .Where(director => director.IsPassive == false);
            List<DirectorsViewModel> vm = _mapper.Map<List<DirectorsViewModel>>(directors);
            return vm;

        }

    }

    public class DirectorsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<DirectorsMovieVM> Movies { get; set; }
        public class DirectorsMovieVM
        {
            public int Id { get; set; }
            public string MovieName { get; set; }
        }
    }
}