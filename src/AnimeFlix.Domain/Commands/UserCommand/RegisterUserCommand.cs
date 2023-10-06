using AnimeFlix.Domain.Validations.UserValidation;
using FluentValidation.Results;

namespace AnimeFlix.Domain.Commands.UserCommand
{
    public class RegisterUserCommand : UserCommand
    {
        public RegisterUserCommand(string name, string bio, string email, string phone)
        {
            Name = name;
            Bio = bio;
            Email = email;
            Phone = phone;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
