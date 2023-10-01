using AnimeFlix.Domain.Commands.AnimeCommand;
using FluentValidation;

namespace AnimeFlix.Domain.Validations.AnimeValidations
{
    public abstract class AnimeValidation<T> : AbstractValidator<T> where T : AnimeCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Invalid Id");
        }
        protected void ValidateName()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Invalid Title")
                .Length(2, 150).WithMessage("Invalid Title Size");                
        }

        protected void ValidateDescription() 
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Invalid Description")
                .Length(2, 500).WithMessage("Invalid Description Size");
        }

        protected void ValidateGenre()
        {
            RuleFor(c => c.Genre)
                .GreaterThan(0).WithMessage("Invalid Genre");
        }

        protected void ValidateReleaseYear()
        {
            RuleFor(c => c.ReleaseYear)
                .GreaterThan(0).WithMessage("Invalid ReleaseYear");
        }


    }
}
