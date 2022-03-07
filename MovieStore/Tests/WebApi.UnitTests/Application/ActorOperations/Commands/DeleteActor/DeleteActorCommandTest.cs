using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeleteActorCommandTests(CommonTestFixture testFixture, IMapper mapper)
        {
            _context = testFixture.Context;
            _mapper = mapper;
        }

        [Fact]
        public void WhenNotFoundActorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.actorID = 20;

            FluentActions.Invoking(()=>command.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Aktör bulunamadı!");

        }

        [Fact]
        public void WhenNotExistMovies_InvalidOperationException_ShouldBeReturn()
        {
            var actor= new Actor { 
            FirstName = "Ahmet", LastName = "Mehmet", MovieActors = new List<MovieActor>(){
               new MovieActor(){Movie = new Movie(){MovieName = "Movie1"}}
            }};
            DeleteActorCommand command=new DeleteActorCommand(_context);
            command.actorID=actor.Id;
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Aktörün filmleri önce silinmeli.");
        }

        [Fact]
        public void WhenValidActorIdIsGiven_Actor_ShouldBeDeleted()
        {
            
            var actor = _context.Actors.SingleOrDefault(
                actor => actor.Id==1);
 
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.actorID = actor.Id;

            FluentActions.Invoking(()=>command.Handle()).Invoke();
            var deletedActor = _context.Actors.
            SingleOrDefault(deletedActor=> deletedActor.Id==command.actorID 
            && deletedActor.IsPassive==false);
            deletedActor.Should().BeNull();

        }

    }
}
