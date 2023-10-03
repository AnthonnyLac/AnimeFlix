using AnimeFlix.Domain.Commands.RatingCommand;

namespace AnimeFlix.Domain.Validations.RatingValidation
{
    public class UpdateRatingCommandValidation : RatingValidation<RatingCommand>
    {
        public UpdateRatingCommandValidation() 
        {
            ValidateId();
            ValidateAnimeId();
        }
    }
}
