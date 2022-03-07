using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotFoundMovieIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context,_mapper);
            query.Id = 1;
            FluentActions.Invoking(()=>query.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Film bulunamadı!");
        }
        
        [Fact]
        public void WhenValidMovieIdIsGiven_Movie_ShouldBeReturn()
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context,_mapper);
            query.Id =1;

            FluentActions.Invoking(()=>query.Handle()).Invoke();

            var movie = _context.Movies.SingleOrDefault(a => a.Id == query.Id);
            movie.Should().NotBeNull();            
        }
    }
}
