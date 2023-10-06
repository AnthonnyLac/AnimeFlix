using AnimeFlix.Domain.Validations.AddressValidation;
using FluentValidation.Results;

namespace AnimeFlix.Domain.Commands.AddressCommand
{
    public class RegisterAddressCommand : AddressCommand
    {
        //c.Street, c.Number, c.Complement, c.City, c.State, c.Country, c.ZipCode
        public RegisterAddressCommand(string street, int number, string complement, string city, string state, string country, string zipCode, int userId)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Complement = complement;
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
