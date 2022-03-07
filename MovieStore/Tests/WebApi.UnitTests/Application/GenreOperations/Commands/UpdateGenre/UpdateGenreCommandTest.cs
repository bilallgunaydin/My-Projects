using System;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DBOperations;
using Xunit;
namespace Tests.WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 20;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Film türü bulunamadı.");
        }

        [Fact]
        public void WhenValidInputAreGiven_Genre_ShouldBeUpdated()
        {

           UpdateGenreCommand command = new UpdateGenreCommand(_context);
            var genre = _context.Genres.SingleOrDefault(genre=> genre.Id==3);
            command.GenreId=genre.Id;
            UpdateGenreModel Model=new UpdateGenreModel
            {
                GenreName="Romance",
            };
            command.Model=Model;

            FluentActions
                .Invoking(()=>command.Handle()).Invoke();

            
            genre.Should().NotBeNull();
            genre.GenreName.Should().Be(Model.GenreName);

        }
    }
}