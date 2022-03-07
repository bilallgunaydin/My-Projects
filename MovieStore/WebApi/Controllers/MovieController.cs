using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.DBOperations;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class MovieController:ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetMovies()
        {
            GetMoviesQuery query =new GetMoviesQuery(_dbContext, _mapper);
            var result=query.Handle();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult GetMovieDetail(int id)
        {
            GetMovieDetailQuery query =new GetMovieDetailQuery(_dbContext, _mapper);
            query.Id=id;
            GetMovieDetailQueryValidator validator= new GetMovieDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieModel model)
        {
            CreateMovieCommand command =new CreateMovieCommand(_dbContext, _mapper);
            command.Model=model;
            CreateMovieCommandValidator validator= new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command =new DeleteMovieCommand(_dbContext);
            command.MovieId=id;
            DeleteMovieCommandValidator validator= new DeleteMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

       [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id,[FromBody] UpdateMovieViewModel model)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_dbContext);
            command.MovieId = id;
            command.Model = model;
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}