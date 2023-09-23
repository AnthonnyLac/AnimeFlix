using AnimeFlix.Domain.Core.Commands;

namespace AnimeFlix.Domain.Commands.AnimeCommand
{
    public abstract class AnimeCommand : Command
    {

        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Genre { get; protected set; }
        public string Rating { get; protected set; }
        public int ReleaseYear { get; protected set; }
        public string CoverImage { get; protected set; }
        public string Trailer { get; protected set; }
    }
}
