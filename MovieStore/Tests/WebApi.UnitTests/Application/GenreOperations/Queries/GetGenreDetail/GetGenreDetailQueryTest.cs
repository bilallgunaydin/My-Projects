using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotFoundGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            query.GenreId = 10;
            FluentActions.Invoking(()=>query.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Film türü bulunamadı.");
        }

        [Fact]
        public void WhenValidGenreIdIsGiven_Genre_ShouldBeReturn()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            query.GenreId = 3;

            FluentActions.Invoking(()=>query.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(a => a.Id == query.GenreId);
            genre.Should().NotBeNull();
           
        }

    }
}
