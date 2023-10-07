using AnimeFlix.Domain.Validations.SubscriptionCommandValidation;

namespace AnimeFlix.Domain.Commands.SubscriptionCommand
{
    public class RegisterSubscriptionCommand : SubscriptionCommand
    {
        public RegisterSubscriptionCommand(int userId, int planId)
        {
            UserId = userId;
            PlanId = planId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterSubscriptionCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
