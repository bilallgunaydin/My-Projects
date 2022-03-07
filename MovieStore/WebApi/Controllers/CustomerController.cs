using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.TokenOperations.Models;
using WebApi.Application.TokenOperations.Commands.CreateToken;
using WebApi.Application.TokenOperations.Commands.RefreshToken;
using WebApi.Application.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.DBOperations;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;


namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel model)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context,_mapper);
            command.Model = model;
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;
            command.Handle();
            return Ok();
        }
        public static string getlogin;

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model = login;
            var token = command.Handle();

            getlogin=login.Email;

            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token){
            RefreshTokenCommand command = new RefreshTokenCommand(_context,_configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();

            return resultToken;
            
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerDetail(int id)
        {
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context,_mapper);
            query.CustomerId=id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost("CreateFavoriteMovie")]
        public IActionResult AddFavoriteMovie([FromBody] CreateFavoriteMovieModel model)
        {
            CreateFavoriteMovie favorite= new CreateFavoriteMovie(_context,_mapper);
            favorite.Model = model;
            if(getlogin!=null)
            favorite.CustomerId=getlogin;

            favorite.Handle();

            return Ok();
        }
 

                
  }
}