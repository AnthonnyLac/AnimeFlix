using AnimeFlix.Domain.Models.User;
using AnimeFlix.Domain.Validations.UserValidation;
using FluentValidation.Results;
using System.Net;

namespace AnimeFlix.Domain.Commands.UserCommand
{
    public class RegisterUserCommand : UserCommand
    {
        public RegisterUserCommand(string name, string bio, string email, string phone, string addressStreet, int addressNumber, string addressComplement, string addressCity, string addressState, string addressCountry, string addressZipCode)
        {
            Name = name;
            Bio = bio;
            Email = email;
            Phone = phone;
            AddressStreet = addressStreet;
            AddressNumber = addressNumber;
            AddressComplement = addressComplement;
            AddressCity = addressCity;
            AddressState = addressState;
            AddressCountry = addressCountry;
            AddressZipCode = addressZipCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
