using AnimeFlix.Domain.Validations.PlanCommandValidation;

namespace AnimeFlix.Domain.Commands.PlanCommand
{
    public class UpdatePlanCommand : PlanCommand
    {
        public UpdatePlanCommand(int id, string name, string description, decimal price, int durationInDays, bool isActive)
        {
            Id = Id;
            Name = name;
            Description = description;
            Price = price;
            DurationInDays = durationInDays;
            IsActive = isActive;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdatePlanCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
