using AnimeFlix.Domain.Models.Anime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Models.Character
{
    public class CharacterModel
    {

        public CharacterModel(string name, string description, string imageUrl, int animeId)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            AnimeId = animeId;
        }
        protected CharacterModel()
        {
        }


        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public int AnimeId { get; private set; }
        public AnimeModel Anime { get; private set; }
        public void SetId(int id) => Id = id;
    }
}
