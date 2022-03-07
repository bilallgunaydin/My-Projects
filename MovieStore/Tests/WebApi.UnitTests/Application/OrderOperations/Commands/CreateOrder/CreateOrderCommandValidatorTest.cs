using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0,0)]
        [InlineData(-1,0,0)]
        [InlineData(0,-1,0)]
        [InlineData(0,0,-1)]
        [InlineData(1,0,1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors
        (int movieID, int customerID, int price)
        {
            CreateOrderCommand command = new CreateOrderCommand(null,null);
            command.Model = new CreateOrderModel
            {
                CustomerId= customerID,
                MovieId=movieID,
                Price=price
            };

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotReturnError()
        {
            CreateOrderCommand command = new CreateOrderCommand(null,null);
            command.Model = new CreateOrderModel
            {
                CustomerId= 1,
                MovieId=1,
                Price=1
            };

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}