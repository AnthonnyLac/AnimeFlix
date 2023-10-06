using AnimeFlix.Domain.Validations.AddressValidation;
using FluentValidation.Results;

namespace AnimeFlix.Domain.Commands.AddressCommand
{
    public class RegisterAddressCommand : AddressCommand
    {
      public RegisterAddressCommand(string street, int number, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
