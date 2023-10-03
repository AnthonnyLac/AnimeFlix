using AnimeFlix.Domain.Commands.RatingCommand;

namespace AnimeFlix.Domain.Validations.RatingValidation
{
    public class DeleteRatingCommandValidation : RatingValidation<RatingCommand>
    {
        public DeleteRatingCommandValidation() 
        {
            ValidateId();
        }
    }
}
