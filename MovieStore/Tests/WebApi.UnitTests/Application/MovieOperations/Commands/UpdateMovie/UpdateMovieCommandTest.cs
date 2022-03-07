using System;
using System.Linq;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;
using WebApi.DBOperations;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyMovieNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId =4;
            command.Model = new UpdateMovieViewModel { MovieName = "UpdateTestMovie"};

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Film bulunamadı.");
        }
        [Fact]
        public void WhenValidInputAreGiven_Movie_ShouldBeUpdated()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId=1;
            var model = new UpdateMovieViewModel { 
            MovieName="UpdateTestMovie", MovieGenreID=1, Price=1, DirectorID=1};
            command.Model = model;
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var movie=_context.Movies.SingleOrDefault(movie=> movie.MovieName==model.MovieName);
            movie.Should().NotBeNull();
            movie.MovieName.Should().Be(model.MovieName);
            movie.DirectorID.Should().Be(model.DirectorID);
            movie.MovieGenreID.Should().Be(model.MovieGenreID);
            movie.Price.Should().Be(model.Price);
            
        }
    }
}