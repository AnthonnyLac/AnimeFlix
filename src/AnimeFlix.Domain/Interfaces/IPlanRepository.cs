using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Plan;

namespace AnimeFlix.Domain.Interfaces
{
    public interface IPlanRepository : IRepository<SubscriptionPlanModel>
    {
        Task<SubscriptionPlanModel> GetByName(string name);
    }
}
