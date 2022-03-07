using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotFoundDirectorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = 10;

            FluentActions.Invoking(()=>command.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Yönetmen bulunamadı.");

        }

        public void WhenNotExistMovies_InvalidOperationException_ShouldBeReturn()
        {
            var director= new Director { 
            FirstName = "Ahmet", LastName = "Mehmet", Movies = new List<Movie>(){
                new Movie(){MovieName = "Movie1"}
            }};
            DeleteDirectorCommand command=new DeleteDirectorCommand(_context);
            command.DirectorId=director.Id;
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Aktörün filmleri önce silinmeli.");
        }

        [Fact]
        public void WhenValidDirectorIdIsGiven_Director_ShouldBeDeleted()
        {
            var director = _context.Directors.SingleOrDefault(
                director => director.Id==1);

            DeleteDirectorCommand command=new DeleteDirectorCommand(_context);
            command.DirectorId=director.Id;

            FluentActions.Invoking(()=>command.Handle()).Invoke();  
            var deletedDirector = _context.Directors.
            SingleOrDefault(deletedDirector=> deletedDirector.Id==command.DirectorId 
            && deletedDirector.IsPassive==false);
            deletedDirector.Should().BeNull();

        }

    }
}
