using AnimeFlix.Domain.Commands.PlanCommand;

namespace AnimeFlix.Domain.Validations.PlanCommandValidation
{
    public class UpdatePlanCommandValidation : PlanValidation<PlanCommand>
    {
        public UpdatePlanCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
        }
    }
}
