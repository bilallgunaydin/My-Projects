using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DirectorViewModel Handle()
        {
            var director= _dbContext.Directors.Include(director => director.Movies)
                                              .OrderBy(director => director.Id)
                                              .Where(director=> director.IsPassive==false)
                                              .SingleOrDefault(director => director.Id == DirectorId);

            if (director is null)
                throw new InvalidOperationException("Yönetmen bulunamadı.");

            DirectorViewModel vm = _mapper.Map<DirectorViewModel>(director);
            return vm;
        }
    }
    public class DirectorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<DirectorMovieVM> Movies { get; set; }
        public class DirectorMovieVM
        {
            public int Id { get; set; }
            public string MovieName { get; set; }
        }
    }
}

