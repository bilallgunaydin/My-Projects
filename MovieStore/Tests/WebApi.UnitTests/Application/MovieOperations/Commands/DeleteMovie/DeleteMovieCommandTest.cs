using System;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotFoundMovieIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId =5;

            FluentActions.Invoking(()=>command.Handle())
                         .Should().Throw<InvalidOperationException>().And.Message
                         .Should().Be("Film bulunamadı.");

        }

        [Fact]
        public void WhenValidMovieIdIsGiven_Movie_ShouldBeDeleted()
        {
            var movie=_context.Movies.SingleOrDefault(m=>m.Id==1);

            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = movie.Id;

            FluentActions.Invoking(()=>command.Handle()).Invoke();
            var findMovie = _context.Movies.SingleOrDefault
            (movie => movie.Id==command.MovieId && movie.IsPassive==false);
            findMovie.Should().BeNull();

        }
    }
}
