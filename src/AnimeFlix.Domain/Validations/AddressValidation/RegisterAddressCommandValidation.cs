using AnimeFlix.Domain.Commands.AddressCommand;
using AnimeFlix.Domain.Validations.AddressCommand;

namespace AnimeFlix.Domain.Validations.AddressValidation
{
    public class RegisterAddressCommandValidation : AddressValidation<RegisterAddressCommand>
    {
        public RegisterAddressCommandValidation()
        {
            ValidateStreet();
            ValidateNumber();
            ValidateCity();
            ValidateState();
            ValidateCountry();
            ValidateZipCode();
            ValidateUserId();
        }
    }
}
