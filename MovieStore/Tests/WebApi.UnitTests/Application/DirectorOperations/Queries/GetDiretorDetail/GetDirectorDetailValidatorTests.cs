using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public GetDirectorDetailValidatorTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenNotFoundDirectorIdIsGiven_InvalidOperationException_ShouldBeReturn(int id)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context,null);
            query.DirectorId =id;
            
            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result=validator.Validate(query);
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidDirectorIdIsGiven_Movie_ShouldBeReturn()
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, null);
            query.DirectorId = 1;

            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);
     
            result.Errors.Count.Should().Be(0);
        }

    }
}