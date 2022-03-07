using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController:ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GenreController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetGenres()
        {
            GetGenresQuery query =new GetGenresQuery(_dbContext, _mapper);
            var result=query.Handle();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query =new GetGenreDetailQuery(_dbContext, _mapper);
            query.GenreId=id;
            GetGenreDetailQueryValidator validator= new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return new JsonResult(result);
        }
        
        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand command =new CreateGenreCommand(_dbContext, _mapper);
            command.Model=model;
            CreateGenreCommandValidator validator= new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command =new DeleteGenreCommand(_dbContext);
            command.GenreId=id;
            DeleteGenreCommandValidator validator= new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand command =new UpdateGenreCommand(_dbContext);
            command.GenreId=id;
            command.Model=model;
            UpdateGenreCommandValidator validator= new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}