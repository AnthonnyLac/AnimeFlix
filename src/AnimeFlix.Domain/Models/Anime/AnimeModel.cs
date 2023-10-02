using AnimeFlix.Domain.Enum;
using AnimeFlix.Domain.Models.Character;

namespace AnimeFlix.Domain.Models.Anime
{
    public class AnimeModel
    {
        public AnimeModel(int id, string title, string description, AnimeCetegory genre, RatingModel rating, int releaseYear, string coverImage, string trailer, IEnumerable<EpisodeModel> animeEpisodes)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
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


        public AnimeModel()
        {
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public AnimeCetegory Genre { get; private set; }
        public int ReleaseYear { get; private set; }
        public string CoverImage { get; private set; }
        public string Trailer { get; private set; }
        public IEnumerable<EpisodeModel> AnimeEpisodes { get; private set; }
        public IEnumerable<CharacterModel> Characters { get; private set; }
        public IEnumerable<RatingModel> Ratings { get; private set; }

        public void SetId(int id) => Id = id;

    }
}
