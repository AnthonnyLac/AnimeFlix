using AnimeFlix.Domain.Commands.UserCommand;

namespace AnimeFlix.Domain.Validations.UserValidation
{
    public class RegisterUserCommandValidation : UserValidation<RegisterUserCommand>
    {
        public RegisterUserCommandValidation()
        {
            ValidateName();
            ValidateBio();
            ValidateEmail();
            ValidatePhone();
        }
    }
}
