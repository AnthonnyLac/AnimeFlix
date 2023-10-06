using AnimeFlix.Domain.Commands.UserCommand;
using FluentValidation;

namespace AnimeFlix.Domain.Validations.UserValidation
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
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

        protected void ValidateBio() 
        {
            RuleFor(c => c.Bio)
                .NotEmpty().WithMessage("Invalid Bio")
                .Length(2, 500).WithMessage("Invalid Bio");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Invalid Email")
                .Length(2, 500).WithMessage("Invalid Email");
        }

         protected void ValidateEmail()
        {
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Invalid Phone")
                .Length(2, 24).WithMessage("Invalid Phone size");
        }

    }
}
