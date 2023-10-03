using AnimeFlix.Domain.Commands.RatingCommand;

namespace AnimeFlix.Domain.Validations.RatingValidation
{
    public class RegisterNewRatingCommandValidation : RatingValidation<RatingCommand>
    {
        public RegisterNewRatingCommandValidation() 
        {
            ValidateAnimeId();
        }
    }
}
