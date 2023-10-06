
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;

namespace AnimeFlix.Domain.Models.User
{
    public class UserModel
    {
        public UserModel(int id, string name, string bio, string email, string phone, IEnumerable<AnimeModel> favoriteAnimes, IEnumerable<CharacterModel> favoriteCharacters, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Bio = bio;
            Email = email;
            Phone = phone;
            FavoriteAnimes = favoriteAnimes;
            FavoriteCharacters = favoriteCharacters;
            CreatedAt = createdAt;
        }

        public UserModel(string name, string bio, string email, string phone)
        {
            Name = name;
            Bio = bio;
            Email = email;
            Phone = phone;
        }

        public UserModel()
        {
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Bio { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public IEnumerable<AnimeModel> FavoriteAnimes { get; private set; }
        public IEnumerable<CharacterModel> FavoriteCharacters { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void SetId(int id) => Id = id;

    }
}
