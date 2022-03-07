using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidCustomerIdIsGiven_Validator_ShouldBeReturnErrors(int directorId)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(null);
            command.CustomerId = directorId;
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidCustomerIdIsGiven_Validator_ShouldNotReturnError()
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(null);
            command.CustomerId = 1;
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }

}