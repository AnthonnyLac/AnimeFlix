using AnimeFlix.Domain.Commands.UserCommand;

namespace AnimeFlix.Domain.Validations.UserValidation
{
    public class DeleteUserCommandValidation : UserValidation<DeleteUserCommand>
    {
        public DeleteUserCommandValidation()
        {
            ValidateId();
        }
    }
}
