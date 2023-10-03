namespace AnimeFlix.Domain.Models.Anime
{
    public class EpisodeModel
    {
        protected EpisodeModel()
        {
        }

        public EpisodeModel( int episodeNumber, string title, string description, string videoUrl, int duration, int animeId)
        {
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
        public AnimeModel Anime { get; private set; }
        public void SetId(int id) => Id = id; 
    }
}
