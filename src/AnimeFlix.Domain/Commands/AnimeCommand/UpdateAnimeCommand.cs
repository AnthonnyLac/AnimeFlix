using AnimeFlix.Domain.Validations.AnimeValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Commands.AnimeCommand
{
    public class UpdateAnimeCommand : AnimeCommand
    {
        public UpdateAnimeCommand(int id, string title, string description, int genre, int releaseYear, string coverImage, string trailer)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
            ReleaseYear = releaseYear;
            CoverImage = coverImage;
            Trailer = trailer;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateAnimeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
