namespace AnimeFlix.Domain.Models.Anime
{
    public class AnimeRatingModel
    {
        public AnimeRatingModel(int id, int animeId, double averageRating, int totalRatings, DateTime lastUpdated)
        {
            Id = id;
            AnimeId = animeId;
            AverageRating = averageRating;
            TotalRatings = totalRatings;
            LastUpdated = lastUpdated;
        }

        public int Id { get; private set; }
        public int AnimeId { get; private set; }
        public double AverageRating { get; private set; }
        public int TotalRatings { get; private set; }
        public DateTime LastUpdated { get; private set; }
    }
}
