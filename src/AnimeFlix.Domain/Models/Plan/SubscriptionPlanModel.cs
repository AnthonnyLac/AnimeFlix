namespace AnimeFlix.Domain.Models.Plan
{
    public class SubscriptionPlanModel
    {
        public SubscriptionPlanModel( string name, string description, decimal price, int durationInDays,  bool isActive)
        {
            Name = name;
            Description = description;
            Price = price;
            DurationInDays = durationInDays;
            IsActive = isActive;
        }
        protected SubscriptionPlanModel() 
        {
        }

        public int Id { get; private set; } 
        public string Name { get; private set; } 
        public string Description { get; private set; } 
        public decimal Price { get; private set; } 
        public int DurationInDays { get; private set; } 
        public bool IsActive { get; private set; } 

        public void SetIdPlan(int id) => Id = id;
    }
}
