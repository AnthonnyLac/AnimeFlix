using AnimeFlix.Domain.Commands.SubscriptionCommand;

namespace AnimeFlix.Domain.Validations.SubscriptionCommandValidation
{
    public class DeleteSubscriptionCommandValidation : SubscriptionValidation<SubscriptionCommand>
    {
        public DeleteSubscriptionCommandValidation() 
        {
            ValidateId();
        }
    }
}
