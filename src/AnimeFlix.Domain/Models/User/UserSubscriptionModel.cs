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
        public UserSubscriptionModel(int userId, SubscriptionPlanModel plan, DateTime subscriptionStartDate, DateTime subscriptionEndDate)
        {
            UserId = userId;
            Plan = plan;
            SubscriptionStartDate = subscriptionStartDate;
            SubscriptionEndDate = subscriptionEndDate;
        }

        protected UserSubscriptionModel() 
        {
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public int PlanId { get; private set; } 
        public SubscriptionPlanModel Plan { get; private set; } 
        public DateTime SubscriptionStartDate { get; private set; } 
        public DateTime SubscriptionEndDate { get; private  set; } 

        private void SetId(int id) => Id = id;
    }
}
