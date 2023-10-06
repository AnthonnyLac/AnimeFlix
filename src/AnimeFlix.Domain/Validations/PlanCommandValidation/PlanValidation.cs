using AnimeFlix.Domain.Commands.EpisodeCommand;
using AnimeFlix.Domain.Commands.PlanCommand;
using FluentValidation;

namespace AnimeFlix.Domain.Validations.PlanCommandValidation
{
    public class PlanValidation<T> : AbstractValidator<T> where T : PlanCommand
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

        protected void ValidatePrice()
        {
            RuleFor(c => c.Price)
                 .GreaterThan(0).WithMessage("Invalid Price");
        }

    
    }
}
