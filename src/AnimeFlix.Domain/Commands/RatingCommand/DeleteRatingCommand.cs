using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Validations.RatingValidation;

namespace AnimeFlix.Domain.Commands.RatingCommand
{
    public class DeleteRatingCommand : RatingCommand
    {
        public DeleteRatingCommand(int id) 
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteRatingCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
