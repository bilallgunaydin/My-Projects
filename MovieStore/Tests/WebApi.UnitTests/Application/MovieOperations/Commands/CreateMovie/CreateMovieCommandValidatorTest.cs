using System;
using System.Collections.Generic;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("",0,1,1,1)]
        [InlineData(" ",1,0,1,2)]
        [InlineData("a",-1,1,1,0)]
        [InlineData("a",1,0,1,0)]
        [InlineData("a",1,1,0,1)]
        [InlineData("a",1,-1,1,3)]
        [InlineData("a",1,0,-1,-1)]
        [InlineData("a",1,1,-1,1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors
        (string movieName, int price, int genreId, int directorId,int actors)
        {
            CreateMovieCommand command= new CreateMovieCommand(null,null);
            CreateMovieModel Model= new CreateMovieModel();
             
                
                Model.MovieName=movieName;
                Model.Price=price;
                Model.MovieGenreID=genreId;
                Model.DirectorID=directorId;
                Model.ReleaseDate=DateTime.Now.AddYears(-1);
                Model.Actors= new List<int>();
                Model.Actors.Add(actors);
                command.Model=Model;
            
              
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateMovieCommand command = new CreateMovieCommand(null,null);
            command.Model = new CreateMovieModel()
            {
                MovieName="movie",
                MovieGenreID=1,
                ReleaseDate=DateTime.Now.Date,
                Price=1,
                DirectorID=1,
                Actors=new List<int>()
                
            };
            
            command.Model.Actors.Add(1);
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotReturnError(){
            CreateMovieCommand command = new CreateMovieCommand(null,null);
            command.Model = new CreateMovieModel{
                MovieName = "Test",
                Price = 10,
                MovieGenreID = 1,
                DirectorID = 1,
                ReleaseDate = DateTime.Now.AddYears(-1),
                Actors = new List<int>()
            };
            command.Model.Actors.Add(1);
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}