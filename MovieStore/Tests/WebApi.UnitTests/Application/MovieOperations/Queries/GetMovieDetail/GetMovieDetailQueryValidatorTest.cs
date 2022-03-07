using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidatorTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public GetMovieDetailQueryValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenNotFoundMovieIdIsGiven_InvalidOperationException_ShouldBeReturn(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context,null);
            query.Id =id;
            
            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            var result=validator.Validate(query);
            
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidMovieIdIsGiven_Movie_ShouldBeReturn()
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, null);
            query.Id = 1;

            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            var result = validator.Validate(query);
     
            result.Errors.Count.Should().Be(0);
        }
    }
}