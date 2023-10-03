using AnimeFlix.Domain.Commands.EpisodeCommand;

namespace AnimeFlix.Domain.Validations.EpisodeCommandValidation
{
    public class RegisterNewEpisodeCommandValidation : EpisodeValidation<EpisodeCommand>
    {
        public RegisterNewEpisodeCommandValidation() 
        {
            ValidateTitle();
            ValidateDescription();
            ValidateVideoUrl();
            ValidateAnimeId();
            ValidateDuration();
            ValidateEpisodeNumber();
        }
    }
}
