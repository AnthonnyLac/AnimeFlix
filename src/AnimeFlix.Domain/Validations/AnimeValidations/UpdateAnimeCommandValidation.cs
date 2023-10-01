using AnimeFlix.Domain.Commands.AnimeCommand;

namespace AnimeFlix.Domain.Validations.AnimeValidations
{
    public class UpdateAnimeCommandValidation : AnimeValidation<UpdateAnimeCommand>
    {
        public UpdateAnimeCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateGenre();
            ValidateDescription();
            ValidateReleaseYear();
        }
    }
}
