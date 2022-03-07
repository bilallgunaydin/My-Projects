using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.CustomerOperations.Commands.CreateFavoriteMovieForCustomer
{
    public class CreateFavoriteMovieForCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidCustomerIdIsGiven_Validator_ShouldBeReturnErrors(string customerId)
        {
            CreateFavoriteMovie command = new CreateFavoriteMovie(null,null);
            command.CustomerId = customerId;
            CreateFavoriteMovieValidator validator = new CreateFavoriteMovieValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidCustomerIdIsGiven_Validator_ShouldNotReturnError()
        {
            CreateFavoriteMovie command = new CreateFavoriteMovie(null,null);
            command.CustomerId = "ahmet";
            CreateFavoriteMovieValidator validator = new CreateFavoriteMovieValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}
