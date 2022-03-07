using System;
using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command=> command.Model.MovieName).NotEmpty().MinimumLength(1);
            RuleFor(command=> command.Model.ReleaseDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=> command.Model.Price).GreaterThan(0);
            RuleFor(command=> command.Model.MovieGenreID).GreaterThan(0);
            RuleFor(command=> command.Model.DirectorID).GreaterThan(0);
            RuleFor(command=> command.Model.Actors).ForEach(x=>x.GreaterThan(0)
                                                   .WithMessage("0 Id'li bir oyuncu girdiniz."));
            RuleFor(commmand=> commmand.Model.Actors)
                   .NotEmpty().WithMessage("Filme ait oyuncu ya da oyuncuları girmediniz.");
        }

    }
}