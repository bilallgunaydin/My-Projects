using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.GenreName)
                   .MinimumLength(2).NotEmpty();
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}