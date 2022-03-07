using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1,"",0,1,1)]
        [InlineData(0," ",1,0,1)]
        [InlineData(1,"a",-1,1,1)]
        [InlineData(0,"a",1,0,1)]
        [InlineData(-1,"a",1,1,0)]
        [InlineData(0,"a",1,-1,1)]
        [InlineData(1,"a",1,0,-1)]
        [InlineData(6,"a",1,1,-1)]
        public void WhenInvalidMovieIdIsGiven_Validator_ShouldBeReturnErrors(int movieId,string movieName, int price, int genreId, int directorId)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.MovieId = movieId;
            command.Model = new UpdateMovieViewModel
            {
                MovieName = movieName,
                Price = price,
                MovieGenreID = genreId,
                DirectorID = directorId,
            };
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1,"a",1,1,1)]
        public void WhenValidMovieIdIsGiven_Validator_ShouldNotReturnError
        (int movieId, string movieName, int price, int genreId, int directorId)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.MovieId = 1;
            command.Model = new UpdateMovieViewModel
            {
                MovieName= movieName,
                Price = price,
                MovieGenreID = genreId,
                DirectorID = directorId,
            };
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}