using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Models.User;

namespace AnimeFlix.Domain.Interfaces
{
    public interface ISubscriptionRepository : IRepository<UserSubscriptionModel>
    {
        Task<UserSubscriptionModel> GetSubscriptionByUserId(int userId);
    }
}
