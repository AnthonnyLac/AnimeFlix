using AnimeFlix.Domain.Commands.UserCommand;

namespace AnimeFlix.Domain.Validations.UserValidation
{
    public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBio();
            ValidateEmail();
            ValidatePhone();
        }
    }
}
