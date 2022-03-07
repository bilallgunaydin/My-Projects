using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("a","b")]
        [InlineData("a","bb")]
        [InlineData("aa","b")]
        [InlineData("a","")]
        [InlineData("","")]
        [InlineData("","b")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string firstName,string lastName){
            CreateDirectorCommand command = new CreateDirectorCommand(null,null);
            command.Model = new CreateDirectorModel{
                FirstName = firstName,
                LastName = lastName
            };

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotReturnError(){
            CreateDirectorCommand command = new CreateDirectorCommand(null,null);
            command.Model = new CreateDirectorModel{
                FirstName = "DirectorFirstName",
                LastName = "DirectorLastName"
            };

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}