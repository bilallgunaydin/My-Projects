using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, "a")]
        [InlineData(0, "")]
        [InlineData(-1, "a")]
        [InlineData(-1, "")]
        [InlineData(1, "a")]
        public void WhenInvalidGenreIdIsGiven_Validator_ShouldBeReturnErrors(int genreId, string genreName)
        {
            UpdateGenreCommand commad = new UpdateGenreCommand(null);
            commad.GenreId = genreId;
            commad.Model = new UpdateGenreModel { GenreName = genreName };
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(commad);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1, "aa")]
        public void WhenValidGenreIdIsGiven_Validator_ShouldNotReturnError(int genreId, string genreName)
        {
            UpdateGenreCommand commad = new UpdateGenreCommand(null);
            commad.GenreId = genreId;
            commad.Model = new UpdateGenreModel { GenreName = genreName };
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(commad);

            result.Errors.Count.Should().Be(0);
        }
    }
}