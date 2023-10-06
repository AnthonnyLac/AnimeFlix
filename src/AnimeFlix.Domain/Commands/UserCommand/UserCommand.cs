using AnimeFlix.Domain.Core.Commands;

namespace AnimeFlix.Domain.Commands.UserCommand
{
    public abstract class UserCommand : Command
    {

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Bio { get; protected set; }
        public string Phone { get; protected set; }
         public string Email { get; protected set; }
        public int[] FavoriteAnimes { get; protected set; }
        public int[] FavoriteCharacters { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
