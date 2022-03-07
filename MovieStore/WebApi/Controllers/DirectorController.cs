using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public DirectorController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetDirectors()
        {
            GetDirectorsQuery query =new GetDirectorsQuery(_dbContext, _mapper);
            var result=query.Handle();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult GetDirectorDetail(int id)
        {
            GetDirectorDetailQuery query =new GetDirectorDetailQuery(_dbContext, _mapper);
            query.DirectorId=id;
            GetDirectorDetailQueryValidator validator= new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return new JsonResult(result);
        }
        
        [HttpPost]
        public IActionResult CreateDirector([FromBody] CreateDirectorModel model)
        {
            CreateDirectorCommand command =new CreateDirectorCommand(_dbContext, _mapper);
            command.Model=model;
            CreateDirectorCommandValidator validator= new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command =new DeleteDirectorCommand(_dbContext);
            command.DirectorId=id;
            DeleteDirectorCommandValidator validator= new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorViewModel model)
        {
            UpdateDirectorCommand command =new UpdateDirectorCommand(_dbContext);
            command.DirectorID=id;
            command.Model=model;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}