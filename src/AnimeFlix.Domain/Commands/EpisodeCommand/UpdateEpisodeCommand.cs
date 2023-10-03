using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Validations.EpisodeCommandValidation;

namespace AnimeFlix.Domain.Commands.EpisodeCommand
{
    public class UpdateEpisodeCommand : EpisodeCommand
    {
        public UpdateEpisodeCommand(int id, int episodeNumber, string title, string description, string videoUrl, int duration, int animeId)
        {
            Id = id;
            EpisodeNumber = episodeNumber;
            Title = title;
            Description = description;
            VideoUrl = videoUrl;
            Duration = duration;
            AnimeId = animeId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateEpisodeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
