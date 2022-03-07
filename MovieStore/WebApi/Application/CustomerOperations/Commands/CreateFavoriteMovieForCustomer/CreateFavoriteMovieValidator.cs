using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateFavoriteMovieValidator : AbstractValidator<CreateFavoriteMovie>
    {
        public CreateFavoriteMovieValidator()
        {
            RuleFor(command => command.Model.Movies).NotEmpty();
            RuleFor(command => command.CustomerId).NotEmpty();
        }
    }
}