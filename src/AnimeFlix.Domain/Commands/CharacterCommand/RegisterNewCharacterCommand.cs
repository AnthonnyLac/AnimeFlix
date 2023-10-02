using AnimeFlix.Domain.Validations.CharacterValidations;

namespace AnimeFlix.Domain.Commands.CharacterCommand
{
    public class RegisterNewCharacterCommand : CharacterCommand
    {
        public RegisterNewCharacterCommand(string name, string description, string imageUrl, int animeId)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            AnimeId = animeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCharacterCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
