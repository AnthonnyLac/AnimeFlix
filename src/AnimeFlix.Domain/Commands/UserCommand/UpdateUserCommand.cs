using AnimeFlix.Domain.Validations.UserValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.UserCommand
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(string name, string bio, string email, string phone)
        {
            Name = name;
            Bio = bio;
            Email = email;
            Phone = phone;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
