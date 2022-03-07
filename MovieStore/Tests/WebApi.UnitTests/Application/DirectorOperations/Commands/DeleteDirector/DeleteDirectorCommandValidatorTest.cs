using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidDirectorIdIsGiven_Validator_ShouldBeReturnErrors(int directorId)
        {
            DeleteDirectorCommand commad = new DeleteDirectorCommand(null);
            commad.DirectorId = directorId;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(commad);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidDirectorIdIsGiven_Validator_ShouldNotReturnError(){
            DeleteDirectorCommand commad = new DeleteDirectorCommand(null);
            commad.DirectorId = 1;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(commad);

            result.Errors.Count.Should().Be(0);
        }

    }

}