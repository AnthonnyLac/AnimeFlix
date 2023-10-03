using AnimeFlix.Domain.Commands.RatingCommand;
using AnimeFlix.Domain.Models.Anime;
using FluentValidation;

namespace AnimeFlix.Domain.Validations.RatingValidation
{
    public class RatingValidation<T> : AbstractValidator<T> where T : RatingCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Invalid Id");
        }

        protected void ValidateAnimeId()
        {
            RuleFor(c => c.AnimeId)
                .GreaterThan(0).WithMessage("Invalid AnimeId");
        }


        protected void ValidateAverageRating()
        {
            RuleFor(c => c.AverageRating)
                .GreaterThan(0).WithMessage("Invalid AverageRating");
        }

        protected void ValidateTotalRatings()
        {
            RuleFor(c => c.TotalRatings)
                .GreaterThan(0).WithMessage("Invalid TotalRatings");
        }
    }
}
