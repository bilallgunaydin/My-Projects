using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyActorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var actor = new Actor { FirstName = "ActorFirstName", LastName = "ActorLastName" };
            _context.Actors.Add(actor);
            _context.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = new CreateActorCommandModel { 
            FirstName = actor.FirstName, LastName = actor.LastName };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Bu aktör zaten var!");
        }

        [Fact]
        public void WhenNotExistMovie_InvalidOperationException_ShouldBeReturn()
        {
            CreateActorCommand command=new CreateActorCommand(_context,_mapper);
            command.Model=new CreateActorCommandModel()
            {
            FirstName = "Ahmet", LastName = "Mehmet", Movies = new List<int>() {0}};

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Girdiğiniz filmler bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Actor_ShouldBeCreated()
        {
            CreateActorCommand command = new CreateActorCommand(_context,_mapper);
            CreateActorCommandModel model = new CreateActorCommandModel();
            model.FirstName="Ahmet";
            model.LastName="Mehmet";
            model.Movies=new List<int>();
            model.Movies.Add(1);
            command.Model = model;

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

            var actor = _context.Actors.
                SingleOrDefault(actor => actor.FirstName.ToLower() == model.FirstName.ToLower() 
                && actor.LastName.ToLower() == model.LastName.ToLower());
            actor.Should().NotBeNull();
            actor.FirstName.Should().Be(model.FirstName);
            actor.LastName.Should().Be(model.LastName);
            actor.MovieActors.Select(MovieActor=> MovieActor.MovieID).Should().BeEquivalentTo(model.Movies);
        }
    }

}