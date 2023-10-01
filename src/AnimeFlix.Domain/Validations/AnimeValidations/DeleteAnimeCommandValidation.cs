using AnimeFlix.Domain.Commands.AnimeCommand;

namespace AnimeFlix.Domain.Validations.AnimeValidations
{
    public class DeleteAnimeCommandValidation : AnimeValidation<DeleteAnimeCommand>
    {
        public DeleteAnimeCommandValidation()
        {
            ValidateId();
        }
    }
}
