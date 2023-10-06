using AnimeFlix.Domain.Validations.AddressValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.AddressCommand
{
    public class DeleteAddressCommand : AddressCommand
    {
        public DeleteAddressCommand(int id) 
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
