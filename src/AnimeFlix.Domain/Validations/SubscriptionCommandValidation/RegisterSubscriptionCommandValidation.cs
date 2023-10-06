using AnimeFlix.Domain.Commands.SubscriptionCommand;

namespace AnimeFlix.Domain.Validations.SubscriptionCommandValidation
{
    public class RegisterSubscriptionCommandValidation : SubscriptionValidation<SubscriptionCommand>
    {
        public RegisterSubscriptionCommandValidation() 
        {
            ValidateUserId();
            ValidatePlanId();
        }
    }
}
