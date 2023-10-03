using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.Anime;

namespace AnimeFlix.Domain.Interfaces
{
    public interface IRatingRepository: IRepository<RatingModel>
    {
        Task<RatingModel> GetByAnimeId(int animeId);
    }
}
