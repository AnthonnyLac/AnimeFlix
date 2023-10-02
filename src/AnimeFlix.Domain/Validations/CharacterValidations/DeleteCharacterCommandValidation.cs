using AnimeFlix.Domain.Commands.CharacterCommand;

namespace AnimeFlix.Domain.Validations.CharacterValidations
{
    public class DeleteCharacterCommandValidation : CharacterValidation<DeleteCharacterCommand>
    {
        public DeleteCharacterCommandValidation()
        {
            ValidateId();
        }
    }
}
