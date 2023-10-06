using AnimeFlix.Domain.Validations.PlanCommandValidation;

namespace AnimeFlix.Domain.Commands.PlanCommand
{
    public class RegisterNewPlanCommand : PlanCommand
    {
        public RegisterNewPlanCommand(string name, string description, decimal price, int durationInDays, bool isActive)
        {
            Name = name;
            Description = description;
            Price = price;
            DurationInDays = durationInDays;
            IsActive = isActive;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPlanCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
