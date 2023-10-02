namespace AnimeFlix.Domain.Models.Anime
{
    public class RatingModel
    {
        public RatingModel(int id, int animeId, double averageRating, int totalRatings, DateTime lastUpdated)
        {
            Id = id;
            AnimeId = animeId;
            AverageRating = averageRating;
            TotalRatings = totalRatings;
            LastUpdated = lastUpdated;
        }
        protected RatingModel()
        {
        }

        public int Id { get; private set; }
        public int AnimeId { get; private set; }
        public AnimeModel Anime { get; private set; }
        public double AverageRating { get; private set; }
        public int TotalRatings { get; private set; }
        public DateTime LastUpdated { get; private set; }
    }
}
