using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.CharacterCommand;
using FluentValidation;

namespace AnimeFlix.Domain.Validations.CharacterValidations
{
    public class RegisterNewCharacterCommandValidation : CharacterValidation<RegisterNewCharacterCommand> 
    {
        public RegisterNewCharacterCommandValidation() 
        {
            ValidateName();
            ValidateDescription();
            ValidateAnimeId();
        }
    }
}
