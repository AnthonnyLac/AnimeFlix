using AnimeFlix.Domain.Commands.EpisodeCommand;

namespace AnimeFlix.Domain.Validations.EpisodeCommandValidation
{
    public class UpdateEpisodeCommandValidation : EpisodeValidation<EpisodeCommand>
    {
        public UpdateEpisodeCommandValidation() 
        {
            ValidateId();
            ValidateTitle();
            ValidateDescription();
            ValidateVideoUrl();
            ValidateAnimeId();
            ValidateDuration();
            ValidateEpisodeNumber();
        }
    }
}
