using AnimeFlix.Domain.Commands.CharacterCommand;

namespace AnimeFlix.Domain.Validations.CharacterValidations
{
    public class UpdateCharacterCommandValidation : CharacterValidation<UpdateCharacterCommand>
    {
        public UpdateCharacterCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateDescription();
            ValidateAnimeId();
        }
    }
}
