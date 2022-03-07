using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using WebApi.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class ActorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

         public ActorController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        [HttpGet]
        public JsonResult GetActors()
        {
            GetActorsQuery query =new GetActorsQuery(_dbContext, _mapper);
            var result=query.Handle();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult GetActorDetail(int id)
        {
            GetActorDetailQuery query =new GetActorDetailQuery(_dbContext, _mapper);
            query.Id=id;
            GetActorDetailQueryValidator validator= new GetActorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] CreateActorCommandModel model)
        {
            CreateActorCommand command =new CreateActorCommand(_dbContext, _mapper);
            command.Model=model;
            CreateActorCommandValidator validator= new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command =new DeleteActorCommand(_dbContext);
            command.actorID=id;
            DeleteActorCommandValidator validator= new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id,[FromBody] UpdateActorViewModel model){
            UpdateActorCommand command = new UpdateActorCommand(_dbContext);
            command.actorID = id;
            command.Model = model;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}