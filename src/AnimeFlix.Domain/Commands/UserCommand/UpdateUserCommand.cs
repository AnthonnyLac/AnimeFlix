using AnimeFlix.Domain.Validations.UserValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.UserCommand
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(int id, string name, string bio, string email, string phone, int addressId, string addressStreet, int addressNumber, string addressComplement, string addressCity, string addressState, string addressCountry, string addressZipCode)
        {
            Id = id;
            Name = name;
            Bio = bio;
            Email = email;
            Phone = phone;
            AddressId = addressId;
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
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
