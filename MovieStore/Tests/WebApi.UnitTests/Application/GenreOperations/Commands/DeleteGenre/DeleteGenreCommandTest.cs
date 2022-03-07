using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotFoundGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = 20;

            FluentActions.Invoking(()=>command.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Film türü bulunamadı.");

        }

         public void WhenNotExistMovies_InvalidOperationException_ShouldBeReturn()
        {
            var genre= new Genre { 
            GenreName = "Test", Movies = new List<Movie>(){
                new Movie(){MovieName = "Movie1"}
            }};

            DeleteGenreCommand command=new DeleteGenreCommand(_context);
            command.GenreId=genre.Id;
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Önce, film türüne ait filmler silinmeli.");
        }

        [Fact]
        public void WhenValidGenreIdIsGiven_Genre_ShouldBeDeleted()
        {

             var genre = _context.Genres.SingleOrDefault(
                genre => genre.Id==1);

            DeleteGenreCommand command=new DeleteGenreCommand(_context);
            command.GenreId=genre.Id;

            FluentActions.Invoking(()=>command.Handle()).Invoke();
            var deletedGenre = _context.Genres.
            SingleOrDefault(deletedGenre=> deletedGenre.Id==command.GenreId 
            && deletedGenre.IsPassive==false);
            deletedGenre.Should().BeNull();
            

        }

    }
}
