using AnimeFlix.Domain.Commands.UserCommand;

namespace AnimeFlix.Domain.Validations.UserValidation
{
    public class RegisterUserCommandValidation : UserValidation<RegisterUserCommand>
    {
        public RegisterUserCommandValidation()
        {
            //Validate User
            ValidateName();
            ValidateBio();
            ValidateEmail();
            ValidatePhone();

            //Validate Address
            ValidateAddressNumber();
            ValidateAddressComplement();
            ValidateAddressCountry();
            ValidateAddressState();
            ValidateAddressStreet();
            ValidateAddressZipCode();
        }
    }
}
