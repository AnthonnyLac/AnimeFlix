using AnimeFlix.Domain.Commands.AddressCommand;
using FluentValidation;

namespace AnimeFlix.Domain.Validations.AddressCommand
{
    public abstract class AddressValidation<T> : AbstractValidator<T> where T : AddressCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Invalid Id");
        }
        
        protected void ValidateStreet()
        {
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("Invalid Street")
                .Length(6, 150).WithMessage("Invalid Street Size");                
        }

        protected void ValidateNumber()
        {
            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("Invalid Number")
                .Length(1, 6).WithMessage("Invalid Number Size");
        }

        protected void ValidateCity()
        {
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Invalid City")
                .Length(2, 150).WithMessage("Invalid City Size");
        }

        protected void ValidateState()
        {
            RuleFor(c => c.State)
                .NotEmpty().WithMessage("Invalid State")
                .Length(2, 150).WithMessage("Invalid State Size");
        }

        protected void ValidateCountry()
        {
            RuleFor(c => c.Country)
                .NotEmpty().WithMessage("Invalid Country")
                .Length(2, 150).WithMessage("Invalid Country Size");
        }

        protected void ValidateZipCode()
        {
            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("Invalid ZipCode")
                .Length(2, 16).WithMessage("Invalid ZipCode Size");
        }

    }
}
