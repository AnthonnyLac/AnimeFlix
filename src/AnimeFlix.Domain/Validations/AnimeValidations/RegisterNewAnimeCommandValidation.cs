using AnimeFlix.Domain.Commands.AnimeCommand;

namespace AnimeFlix.Domain.Validations.AnimeValidations
{
    public class RegisterNewAnimeCommandValidation : AnimeValidation<RegisterNewAnimeCommand>
    {
        public RegisterNewAnimeCommandValidation()
        {
            ValidateName();
            ValidateGenre();
            ValidateDescription();
            ValidateReleaseYear();
        }
    }
}
