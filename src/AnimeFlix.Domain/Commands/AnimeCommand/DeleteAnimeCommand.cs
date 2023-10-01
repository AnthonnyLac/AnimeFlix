using AnimeFlix.Domain.Validations.AnimeValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.AnimeCommand
{
    public class DeleteAnimeCommand : AnimeCommand
    {
        public DeleteAnimeCommand(int id) 
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeleteAnimeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
