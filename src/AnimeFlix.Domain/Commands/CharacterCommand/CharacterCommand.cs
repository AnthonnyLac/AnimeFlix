using AnimeFlix.Domain.Core.Commands;

namespace AnimeFlix.Domain.Commands.CharacterCommand
{
    public class CharacterCommand : Command
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ImageUrl { get; protected set; }
        public int AnimeId { get; protected set; }
    }
}
