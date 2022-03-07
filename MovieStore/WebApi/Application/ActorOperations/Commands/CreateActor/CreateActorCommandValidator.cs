using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(command=> command.Model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(command=> command.Model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(command=> command.Model.Movies).ForEach(x=>x.GreaterThan(0)
                                                   .WithMessage("0 Id'li bir film girdiniz."));
            RuleFor(commmand=> commmand.Model.Movies)
                   .NotEmpty().WithMessage("Oyuncuya ait film ya da filmleri girmediniz.");
        }
    }
}