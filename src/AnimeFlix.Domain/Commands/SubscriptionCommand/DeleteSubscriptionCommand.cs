using AnimeFlix.Domain.Validations.SubscriptionCommandValidation;

namespace AnimeFlix.Domain.Commands.SubscriptionCommand
{
    public class DeleteSubscriptionCommand : SubscriptionCommand
    {
        public DeleteSubscriptionCommand(int id) 
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteSubscriptionCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
