using AnimeFlix.Domain.Commands.CharacterCommand;
using FluentValidation;

namespace AnimeFlix.Domain.Validations.CharacterValidations
{
    public class CharacterValidation<T> : AbstractValidator<T> where T : CharacterCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Invalid Id");
        }
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Invalid Name")
                .Length(2, 150).WithMessage("Invalid Name Size");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Invalid Description")
                .Length(2, 500).WithMessage("Invalid Description Size");
        }

        protected void ValidateAnimeId()
        {
            RuleFor(c => c.AnimeId)
                .GreaterThan(0).WithMessage("Invalid AnimeId");
        }

    }
}
