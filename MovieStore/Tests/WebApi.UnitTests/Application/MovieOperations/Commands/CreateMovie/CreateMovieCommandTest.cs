using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.WebApi.UnitTests.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]

        public void WhenAlreadyExistMovieMovieNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var movie=new Movie()
            {
                MovieName="Movie1",
                MovieGenreID=1,
                Price=1,
                ReleaseDate=new DateTime(2020,01,01),
                
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            
            CreateMovieCommand command=new CreateMovieCommand(_context,_mapper);
            command.Model=new CreateMovieModel(){MovieName=movie.MovieName};

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film zaten mevcut.");
        }

        [Fact]
        public void WhenNotExistDirectorID_InvalidOperationException_ShouldBeReturn()
        {
            CreateMovieCommand command=new CreateMovieCommand(_context,_mapper);
            command.Model=new CreateMovieModel(){ MovieName="Test",DirectorID=0};


            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Girdiğiniz yönetmen bulunamadı.");
        }
        [Fact]
        public void WhenNotExistMovieGenreID_InvalidOperationException_ShouldBeReturn()
        {
            CreateMovieCommand command=new CreateMovieCommand(_context,_mapper);
            command.Model=new CreateMovieModel(){MovieName="test", DirectorID=1, MovieGenreID=0};

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Girdiğiniz film türü bulunamadı.");
        }

        [Fact]
        public void WhenNotExistActors_InvalidOperationException_ShouldBeReturn()
        {
            CreateMovieCommand command=new CreateMovieCommand(_context,_mapper);
            command.Model=new CreateMovieModel(){
            MovieName="Test", DirectorID=1, MovieGenreID=1, Actors = new List<int>() {0}};

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message
                .Should().Be("Girdiğiniz oyuncular bulunamadı.");
        }

        [Fact]
        public void WhenValidInputGiven_Movie_ShouldBeCreate()
        {
            CreateMovieCommand command=new CreateMovieCommand(_context,_mapper);
            CreateMovieModel model = new CreateMovieModel()
            {MovieName="Movie1123123",DirectorID=1,MovieGenreID=1,Actors = new List<int>() {1,2}};
            command.Model=model;

            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var movie=_context.Movies.SingleOrDefault(movie=> movie.MovieName==model.MovieName);
            movie.Should().NotBeNull();
            movie.MovieName.Should().Be(model.MovieName);
            movie.DirectorID.Should().Be(model.DirectorID);
            movie.MovieGenreID.Should().Be(model.MovieGenreID);
            movie.Price.Should().Be(model.Price);
            movie.ReleaseDate.Should().Be(model.ReleaseDate);
            movie.MovieActors.Select(movieActor=> movieActor.ActorID).Should().BeEquivalentTo(model.Actors);
        }

    }
}