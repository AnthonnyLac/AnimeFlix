using AnimeFlix.Domain.Commands.EpisodeCommand;

namespace AnimeFlix.Domain.Validations.EpisodeCommandValidation
{
    public class DeleteEpisodeCommandValidation : EpisodeValidation<EpisodeCommand>
    {
        public DeleteEpisodeCommandValidation() 
        {
            ValidateId();
        }
    }
}
