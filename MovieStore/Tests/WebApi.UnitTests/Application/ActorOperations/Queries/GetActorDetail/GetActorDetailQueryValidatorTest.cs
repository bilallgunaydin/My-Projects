using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidatorTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public GetActorDetailQueryValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenNotFoundActorIdIsGiven_InvalidOperationException_ShouldBeReturn(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context,null);
            query.Id =id;
            
            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            var result=validator.Validate(query);
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidActorIdIsGiven_Movie_ShouldBeReturn()
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, null);
            query.Id = 1;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            var result = validator.Validate(query);
     
            result.Errors.Count.Should().Be(0);
        }

    }
}