using AnimeFlix.Domain.Validations.AnimeValidations;
using AnimeFlix.Domain.Validations.CharacterValidations;

namespace AnimeFlix.Domain.Commands.CharacterCommand
{
    public class DeleteCharacterCommand : CharacterCommand
    {
        public DeleteCharacterCommand(int id) 
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteCharacterCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
