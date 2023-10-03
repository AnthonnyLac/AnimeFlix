using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Models.Anime;

namespace AnimeFlix.Domain.Commands.RatingCommand
{
    public abstract class RatingCommand : Command
    {
        public int Id { get; protected set; }
        public int AnimeId { get; protected set; }
        public AnimeModel Anime { get; protected set; }
        public double AverageRating { get; protected set; }
        public int TotalRatings { get; protected set; }
        public DateTime LastUpdated { get; protected set; }

    }
}
