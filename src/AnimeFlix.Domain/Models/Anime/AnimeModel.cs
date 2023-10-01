using AnimeFlix.Domain.Enum;

namespace AnimeFlix.Domain.Models.Anime
{
    public class AnimeModel
    {
        public AnimeModel(int id, string title, string description, AnimeCetegory genre, AnimeRatingModel rating, int releaseYear, string coverImage, string trailer, IEnumerable<AnimeEpisodeModel> animeEpisodes)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
            Rating = rating;
            ReleaseYear = releaseYear;
            CoverImage = coverImage;
            Trailer = trailer;
            AnimeEpisodes = animeEpisodes;
        }
        public AnimeModel(string title, string description, AnimeCetegory genre, int releaseYear, string coverImage, string trailer)
        {
            Title = title;
            Description = description;
            Genre = genre;
            ReleaseYear = releaseYear;
            CoverImage = coverImage;
            Trailer = trailer;
        }


        protected AnimeModel()
        {
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public AnimeCetegory Genre { get; private set; }
        public AnimeRatingModel Rating { get; private set; }
        public int ReleaseYear { get; private set; }
        public string CoverImage { get; private set; }
        public string Trailer { get; private set; }
        public IEnumerable<AnimeEpisodeModel> AnimeEpisodes { get; private set; }
        public void SetId(int id) => Id = id;

    }
}
