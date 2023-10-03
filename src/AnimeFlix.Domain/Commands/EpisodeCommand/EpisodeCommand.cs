using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Models.Anime;

namespace AnimeFlix.Domain.Commands.EpisodeCommand
{
    public abstract class EpisodeCommand : Command
    {
        public int Id { get; protected set; }
        public int EpisodeNumber { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string VideoUrl { get; protected set; }
        public int Duration { get; protected set; }
        public int AnimeId { get; protected set; }
        public AnimeModel Anime { get; protected set; }

    }
}
