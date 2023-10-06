using AnimeFlix.Domain.Commands.AddressCommand;

namespace AnimeFlix.Domain.Validations.AddressValidation
{
    public class UpdateAddressCommandValidation : AddressValidation<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidation()
        {
            ValidateStreet();
            ValidateNumber();
            ValidateCity();
            ValidateState();
            ValidateCountry();
            ValidateZipCode();
        }
    }
}
