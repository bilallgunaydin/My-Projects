using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("a","b","","asd")]
        [InlineData("a","bb","","asd")]
        [InlineData("aa","b","a","asda")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors
        (string firstName,string lastName, string email, string password)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null,null);
            command.Model = new CreateCustomerModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotReturnError()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null,null);
            command.Model = new CreateCustomerModel
            {
                FirstName = "CustomerFirstName",
                LastName = "CustomerLastName",
                Email = "customer@gmail.com",
                Password = "12345678"
            };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}