using AnimeFlix.Domain.Validations.AnimeValidations;
using FluentValidation.Results;

namespace AnimeFlix.Domain.Commands.AnimeCommand
{
    public class RegisterNewAnimeCommand : AnimeCommand
    {
        public RegisterNewAnimeCommand(string title, string description, int genre,  int releaseYear, string coverImage, string trailer)
        {
            Title = title;
            Description = description;
            Genre = genre;
            ReleaseYear = releaseYear;
            CoverImage = coverImage;
            Trailer = trailer;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewAnimeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
