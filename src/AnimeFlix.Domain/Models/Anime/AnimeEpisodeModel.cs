namespace AnimeFlix.Domain.Models.Anime
{
    public class AnimeEpisodeModel
    {
        public AnimeEpisodeModel(int id, int episodeNumber, string title, string description, string videoUrl, int duration, int animeId)
        {
            Id = id;
            EpisodeNumber = episodeNumber;
            Title = title;
            Description = description;
            VideoUrl = videoUrl;
            Duration = duration;
            AnimeId = animeId;

        }

        public int Id { get; private set; }
        public int EpisodeNumber { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string VideoUrl { get; private set; }
        public int Duration { get; private set; }
        public int AnimeId { get; private set; }
    }
}
