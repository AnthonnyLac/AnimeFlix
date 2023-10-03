using AnimeFlix.Domain.Validations.RatingValidation;

namespace AnimeFlix.Domain.Commands.RatingCommand
{
    public class UpdateRatingCommand : RatingCommand
    {
        public UpdateRatingCommand(int id, int animeId, double averageRating, int totalRatings)
        {
            Id = id;
            AnimeId = animeId;
            AverageRating = averageRating;
            TotalRatings = totalRatings;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRatingCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
