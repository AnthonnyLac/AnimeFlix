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

        protected void ValidatePhone()
        {
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Invalid Phone")
                .Length(2, 24).WithMessage("Invalid Phone Size");
        }

        protected void ValidateAddressId()
        {
            RuleFor(c => c.AddressId)
                .GreaterThan(0).WithMessage("Invalid AddressId");
        }

        protected void ValidateAddressNumber()
        {
            RuleFor(c => c.AddressNumber)
                .GreaterThan(0).WithMessage("Invalid AddressNumber");
        }

        protected void ValidateAddressComplement()
        {
            RuleFor(c => c.AddressComplement)
                .NotEmpty().WithMessage("Invalid AddressComplement")
                .Length(2, 500).WithMessage("Invalid AddressComplement");
        }

        protected void ValidateAddressCountry()
        {
            RuleFor(c => c.AddressCountry)
                .NotEmpty().WithMessage("Invalid AddressCountry")
                .Length(2, 50).WithMessage("Invalid AddressCountry");
        }

        protected void ValidateAddressState()
        {
            RuleFor(c => c.AddressState)
                .NotEmpty().WithMessage("Invalid AddressState")
                .Length(2, 2).WithMessage("Invalid AddressState");
        }

        protected void ValidateAddressStreet()
        {
            RuleFor(c => c.AddressStreet)
                .NotEmpty().WithMessage("Invalid AddressStreet")
                .Length(2, 500).WithMessage("Invalid AddressStreet");
        }

        protected void ValidateAddressZipCode()
        {
            RuleFor(c => c.AddressZipCode)
                .NotEmpty().WithMessage("Invalid AddressZipCode")
                .Length(2, 50).WithMessage("Invalid AddressZipCode");
        }
    }
}
