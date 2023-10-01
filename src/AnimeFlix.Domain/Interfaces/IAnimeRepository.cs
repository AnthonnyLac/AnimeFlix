using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.Anime;

namespace AnimeFlix.Domain.Interfaces
{
    public interface IAnimeRepository : IRepository<AnimeModel>
    {
        Task<AnimeModel> GetByName(string name);
    }
}
