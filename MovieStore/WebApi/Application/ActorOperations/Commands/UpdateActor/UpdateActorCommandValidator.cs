using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
           RuleFor(command=> command.actorID).GreaterThan(0);
           RuleFor(command=> command.Model.FirstName).NotEmpty().MinimumLength(2);
           RuleFor(command=> command.Model.LastName).NotEmpty().MinimumLength(2);
           RuleFor(command=> command.Model.IsPassive).NotNull();
        }
    }
}