using AnimeFlix.Domain.Commands.PlanCommand;

namespace AnimeFlix.Domain.Validations.PlanCommandValidation
{
    public class RegisterNewPlanCommandValidation : PlanValidation<PlanCommand>
    {
        public RegisterNewPlanCommandValidation() 
        {
            ValidateName();
            ValidatePrice();
        }
    }
}
