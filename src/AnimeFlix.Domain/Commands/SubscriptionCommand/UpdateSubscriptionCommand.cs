using AnimeFlix.Domain.Validations.SubscriptionCommandValidation;

namespace AnimeFlix.Domain.Commands.SubscriptionCommand
{
    public class UpdateSubscriptionCommand : SubscriptionCommand
    {
        public UpdateSubscriptionCommand(int id, int userId, int planId)
        {
            Id = id;
            UserId = userId;
            PlanId = planId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateSubscriptionCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
