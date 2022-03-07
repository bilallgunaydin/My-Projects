using System;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyActorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.actorID=5;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Aktör bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Actor_ShouldBeUpdated()
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            var actor = _context.Actors.SingleOrDefault(actor=> actor.Id==3);

            UpdateActorViewModel model = new UpdateActorViewModel 
            { FirstName="FirstName",LastName="LastName"};
            command.actorID = actor.Id;
            command.Model = model;

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

            
            actor.Should().NotBeNull();
            actor.FirstName.Should().Be(model.FirstName);
            actor.LastName.Should().Be(model.LastName);

        }
    }

}