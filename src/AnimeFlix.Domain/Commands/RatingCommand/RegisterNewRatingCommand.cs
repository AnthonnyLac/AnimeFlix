using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Validations.RatingValidation;

namespace AnimeFlix.Domain.Commands.RatingCommand
{
    public class RegisterNewRatingCommand : RatingCommand
    {
        public RegisterNewRatingCommand(int animeId, double averageRating, int totalRatings)
        {
            AnimeId = animeId;
            AverageRating = averageRating;
            TotalRatings = totalRatings;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewRatingCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
