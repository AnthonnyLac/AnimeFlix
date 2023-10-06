using AnimeFlix.Domain.Commands.AddressCommand;
using AnimeFlix.Domain.Validations.AddressCommand;

namespace AnimeFlix.Domain.Validations.AddressValidation
{
    public class DeleteAddressCommandValidation : AddressValidation<DeleteAddressCommand>
    {
        public DeleteAddressCommandValidation()
        {
            ValidateId();
        }
    }
}
