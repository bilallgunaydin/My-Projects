using System;
using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command=> command.MovieId).GreaterThan(0);
            RuleFor(command=> command.Model.MovieName).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.Price).GreaterThanOrEqualTo(0);
            RuleFor(command => command.Model.MovieGenreID).GreaterThan(0);
            RuleFor(command => command.Model.DirectorID).GreaterThan(0);
            RuleFor(command => command.Model.ReleaseDate).LessThan(DateTime.Now);
            RuleFor(command => command.MovieId).GreaterThan(0);
        }
    }
}