using AnimeFlix.Domain.Models.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeFlix.Domain.Models.User
{
    public class UserSubscriptionModel
    {
        public UserSubscriptionModel(int userId, int planId, DateTime subscriptionStartDate, DateTime subscriptionEndDate)
        {
            UserId = userId;
            PlanId = planId;
            SubscriptionStartDate = subscriptionStartDate;
            SubscriptionEndDate = subscriptionEndDate;
        }

        protected UserSubscriptionModel() 
        {
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public UserModel User { get; private set; }
        public int PlanId { get; private set; }
        public SubscriptionPlanModel Plan { get; private set; }
        public DateTime SubscriptionStartDate { get; private set; }
        public DateTime SubscriptionEndDate { get; private set; }

        public void SetId(int id) => Id = id;
    }
}
