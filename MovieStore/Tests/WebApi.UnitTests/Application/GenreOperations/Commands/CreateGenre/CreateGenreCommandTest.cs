using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var genre = new Genre { GenreName = "TestGenre" };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = new CreateGenreModel { GenreName = genre.GenreName};

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Film türü zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Genre_ShouldBeCreated(){
            CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
            var model = new CreateGenreModel { GenreName="GenreTest"};
            command.Model = model;

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

            var genre = _context.Genres.FirstOrDefault(genre => genre.GenreName == model.GenreName);
            genre.Should().NotBeNull();
            genre.GenreName.Should().Be(model.GenreName);

        }
    }

}