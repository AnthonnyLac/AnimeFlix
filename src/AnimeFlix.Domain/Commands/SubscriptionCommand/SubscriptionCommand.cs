using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Models.Plan;
using AnimeFlix.Domain.Models.User;

namespace AnimeFlix.Domain.Commands.SubscriptionCommand
{
    public abstract class SubscriptionCommand : Command
    {
        public int Id { get; protected set; }
        public int UserId { get; protected set; }
        public UserModel User { get; protected set; }
        public int PlanId { get; protected set; }
        public SubscriptionPlanModel Plan { get; protected set; }
        public DateTime SubscriptionStartDate { get; protected set; }
        public DateTime SubscriptionEndDate { get; protected set; }
    }
}
