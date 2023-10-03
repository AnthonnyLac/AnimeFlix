using AnimeFlix.Domain.Validations.EpisodeCommandValidation;

namespace AnimeFlix.Domain.Commands.EpisodeCommand
{
    public class DeleteEpisodeCommand : EpisodeCommand
    {
        public DeleteEpisodeCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteEpisodeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
