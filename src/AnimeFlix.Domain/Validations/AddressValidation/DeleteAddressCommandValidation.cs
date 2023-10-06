using AnimeFlix.Domain.Commands.AddressCommand;

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
