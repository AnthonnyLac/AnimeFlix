using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Models.User;

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
        public int AddressId { get; protected set; }
        public string AddressStreet { get; protected set; }
        public int AddressNumber { get; protected set; }
        public string AddressComplement { get; protected set; }
        public string AddressCity { get; protected set; }
        public string AddressState { get; protected set; }
        public string AddressCountry { get; protected set; }
        public string AddressZipCode { get; protected set; }
    }
}
