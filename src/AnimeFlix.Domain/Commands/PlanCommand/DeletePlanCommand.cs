using AnimeFlix.Domain.Validations.PlanCommandValidation;

namespace AnimeFlix.Domain.Commands.PlanCommand
{
    public class DeletePlanCommand : PlanCommand
    {
        public DeletePlanCommand(int id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new DeletePlanCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
