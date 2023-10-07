namespace AnimeFlix.Application.ViewModels
{
    public class SubscriptionViewModel : ViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlanId { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
    }
}
