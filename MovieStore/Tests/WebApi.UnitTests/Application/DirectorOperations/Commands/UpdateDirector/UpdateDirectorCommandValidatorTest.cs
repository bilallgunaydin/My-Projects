using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"","",true)]
        [InlineData(1,"a","",true)]
        [InlineData(0,"","b",true)]
        [InlineData(0,"","a",true)]
        [InlineData(1,"","b",true)]
        [InlineData(0,"a"," ",true)]
        [InlineData(1," ","",false)]
        public void WhenInvalidDirectorIdIsGiven_Validator_ShouldBeReturnErrors
        (int directorId,string firstName,string lastName,bool isPassive)
        {
            UpdateDirectorCommand commad = new UpdateDirectorCommand(null);
            commad.Model = new UpdateDirectorViewModel{
                FirstName=firstName,
                LastName=lastName,
                IsPassive=isPassive
            };
            commad.DirectorID = directorId;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(commad);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1,"aa","aa",true)]
        [InlineData(1,"up","up",false)]
        public void WhenValidDirectorIdIsGiven_Validator_ShouldNotReturnError
        (int directorId,string firstName,string lastName,bool isPassive)
        {
            UpdateDirectorCommand commad = new UpdateDirectorCommand(null);
            commad.Model = new UpdateDirectorViewModel{
                FirstName=firstName,
                LastName=lastName,
                IsPassive=isPassive
            };
            commad.DirectorID = directorId;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(commad);


            result.Errors.Count.Should().Be(0);
        }

    }

}