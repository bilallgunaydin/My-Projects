using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.OrderOperations.Commands.UpdateOrder;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1,-1,1)]
        [InlineData(1,0,-1)]
        [InlineData(1,1,-1)]
        public void WhenInvalidOrderIdIsGiven_Validator_ShouldBeReturnErrors
        (int customerId,int movieId, int price)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(null);
            command.OrderId = movieId;
            command.Model = new UpdateOrderViewModel
            {
                CustomerId = customerId,
                MovieId = movieId,
                Price = price,
            };
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1,1,1)]
        public void WhenValidMovieIdIsGiven_Validator_ShouldNotReturnError
        (int customerId,int movieId, int price)
        {
           UpdateOrderCommand command = new UpdateOrderCommand(null);
            command.OrderId = 1;
            command.Model = new UpdateOrderViewModel
            {
                CustomerId = customerId,
                MovieId = movieId,
                Price = price,
            };
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }

}