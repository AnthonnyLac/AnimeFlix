using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Models
{
    public class AnimeModel
    {
        public AnimeModel(int id, string title, string description, string genre, string rating, int releaseYear, string coverImage, string trailer)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
            Rating = rating;
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
        public string Genre { get; private set; }
        public string Rating { get; private set; }
        public int ReleaseYear { get; private set; }
        public string CoverImage { get; private set; }
        public string Trailer { get; private set; }
    }
}
