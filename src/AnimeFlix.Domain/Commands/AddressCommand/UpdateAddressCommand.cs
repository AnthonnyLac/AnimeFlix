using AnimeFlix.Domain.Validations.AddressValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.AddressCommand
{
    public class UpdateAddressCommand : AddressCommand
    {
        public UpdateAddressCommand(string street, int number, string complement, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new UpdateAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
