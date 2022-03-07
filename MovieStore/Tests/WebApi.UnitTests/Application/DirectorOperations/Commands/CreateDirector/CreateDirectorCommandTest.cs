using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyDirectorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
           var director = new Director { FirstName = "DirectorFirstName", LastName = "ActorLastName" };
            _context.Directors.Add(director);
            _context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = new CreateDirectorModel { 
            FirstName = director.FirstName, LastName = director.LastName };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Yönetmen zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Director_ShouldBeCreated(){
            CreateDirectorCommand command = new CreateDirectorCommand(_context,_mapper);
            var model = new CreateDirectorModel { FirstName="DirectorFirstName",LastName="DirectorLastName"};
            command.Model = model;

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

            var director = _context.Directors
            .FirstOrDefault(Director => Director.FirstName.ToLower() == model.FirstName.ToLower() && 
                            Director.LastName.ToLower() == model.LastName.ToLower());
            director.Should().NotBeNull();
            director.FirstName.Should().Be(model.FirstName);
            director.LastName.Should().Be(model.LastName);

        }
    }

}