using AnimeFlix.Domain.Validations.UserValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.UserCommand
{
    public class DeleteUserCommand : UserCommand
    {
        public DeleteUserCommand(int id) 
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
