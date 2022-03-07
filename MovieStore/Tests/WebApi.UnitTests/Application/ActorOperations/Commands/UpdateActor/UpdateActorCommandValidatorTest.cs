using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"","")]
        [InlineData(0,"a","b")]
        [InlineData(0,"a","ab")]
        [InlineData(0,"ab","a")]
        [InlineData(0,"adf","a")]
        [InlineData(0,"","a")]
        [InlineData(0,"","b")]
        [InlineData(0,"a","")]
        [InlineData(-1,"a","b")]
        [InlineData(-1,"a","ab")]
        [InlineData(-1,"ab","b")]
        [InlineData(-1,"ab","")]
        [InlineData(-1,"","ab")]
        [InlineData(-1,"","b")]
        [InlineData(-1,"a","")]
        [InlineData(1,"a","b")]
        [InlineData(1,"a","ab")]
        [InlineData(1,"ab","b")]
        [InlineData(1,"","b")]
        [InlineData(1,"a","")]
        public void WhenInvalidActorIdIsGiven_Validator_ShouldBeReturnErrors
        (int actorId,string firstName,string lastName)
        {
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.actorID = actorId;
            command.Model = new UpdateActorViewModel
            {
                FirstName=firstName,LastName=lastName
            };
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1,"aa","aa")]
        public void WhenValidActorIdIsGiven_Validator_ShouldNotReturnError
        (int actorId,string firstName,string lastName)
        {
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.actorID = actorId;
            command.Model = new UpdateActorViewModel
            {
                FirstName=firstName,LastName=lastName
            };
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }

}