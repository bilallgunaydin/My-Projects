using System.Collections.Generic;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("","",0)]
        [InlineData(" "," ",1)]
        [InlineData("a","a",-1)]
        [InlineData("a","ab",0)]
        [InlineData("ab","a",0)]
        [InlineData("ab","",-1)]
        [InlineData("","ab",1)]
        [InlineData("","b",-3)]
        [InlineData("a","",1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors
        (string firstName,string lastName,int movies)
        {
            CreateActorCommand command = new CreateActorCommand(null,null);
            CreateActorCommandModel Model = new CreateActorCommandModel
            {
                FirstName = firstName,
                LastName = lastName
            };
            Model.Movies=new List<int>();
            Model.Movies.Add(movies);
            command.Model = Model;

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotReturnError()
        {
           CreateActorCommand command = new CreateActorCommand(null,null);
            CreateActorCommandModel Model = new CreateActorCommandModel
            {
                FirstName = "Ahmet",
                LastName = "Şükrü"
            };
            Model.Movies=new List<int>();
            Model.Movies.Add(1);
            command.Model = Model;

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}