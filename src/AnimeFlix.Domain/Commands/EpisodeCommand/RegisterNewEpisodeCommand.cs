using AnimeFlix.Domain.Validations.EpisodeCommandValidation;

namespace AnimeFlix.Domain.Commands.EpisodeCommand
{
    public class RegisterNewEpisodeCommand : EpisodeCommand
    {
        public RegisterNewEpisodeCommand(int episodeNumber, string title, string description, string videoUrl, int duration, int animeId)
        {
            EpisodeNumber = episodeNumber;
            Title = title;
            Description = description;
            VideoUrl = videoUrl;
            Duration = duration;
            AnimeId = animeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewEpisodeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
