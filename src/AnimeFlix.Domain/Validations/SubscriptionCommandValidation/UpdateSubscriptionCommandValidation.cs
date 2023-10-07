using AnimeFlix.Domain.Commands.SubscriptionCommand;

namespace AnimeFlix.Domain.Validations.SubscriptionCommandValidation
{
    public class UpdateSubscriptionCommandValidation :  SubscriptionValidation<SubscriptionCommand>
    {
        public UpdateSubscriptionCommandValidation() 
        {
            ValidateId();
            ValidateUserId();
            ValidatePlanId();
        }
    }
}
