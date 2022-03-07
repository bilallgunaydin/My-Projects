using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.OrderOperations.Queries.GetOrderDetail;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryValidatorTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public GetOrderDetailQueryValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenNotFoundOrderIdIsGiven_InvalidOperationException_ShouldBeReturn(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context,null);
            query.OrderId =id;
            
            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            var result=validator.Validate(query);
            
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidMovieIdIsGiven_Movie_ShouldBeReturn()
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, null);
            query.OrderId = 1;

            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            var result = validator.Validate(query);
     
            result.Errors.Count.Should().Be(0);
        }

    }
}