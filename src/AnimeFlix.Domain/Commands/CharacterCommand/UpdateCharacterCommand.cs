using AnimeFlix.Domain.Validations.CharacterValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.CharacterCommand
{
    public class UpdateCharacterCommand : CharacterCommand
    {
        public UpdateCharacterCommand(int id, string name, string description, string imageUrl, int animeId)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            AnimeId = animeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCharacterCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
