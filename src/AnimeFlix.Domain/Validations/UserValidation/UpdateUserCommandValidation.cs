using AnimeFlix.Domain.Commands.UserCommand;

namespace AnimeFlix.Domain.Validations.UserValidation
{
    public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            //Validate User
            ValidateId();
            ValidateName();
            ValidateBio();
            ValidateEmail();
            ValidatePhone();

            //Validate Address
            ValidateAddressId();
            ValidateAddressNumber();
            ValidateAddressComplement();
            ValidateAddressCountry();
            ValidateAddressState();
            ValidateAddressStreet();
            ValidateAddressZipCode();
        }
    }
}
