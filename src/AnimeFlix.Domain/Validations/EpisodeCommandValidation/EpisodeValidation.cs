using AnimeFlix.Domain.Commands.EpisodeCommand;
using FluentValidation;

namespace AnimeFlix.Domain.Validations.EpisodeCommandValidation
{
    public class EpisodeValidation<T> : AbstractValidator<T> where T : EpisodeCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Invalid Id");
        }
        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Invalid Title")
                .Length(2, 150).WithMessage("Invalid Title Size");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Invalid Description")
                .Length(2, 500).WithMessage("Invalid Description Size");
        }
        protected void ValidateVideoUrl()
        {
            RuleFor(c => c.VideoUrl)
                .NotEmpty().WithMessage("Invalid Description")
                .Length(2, 500).WithMessage("Invalid Description Size");
        }

        protected void ValidateAnimeId()
        {
            RuleFor(c => c.AnimeId)
                .GreaterThan(0).WithMessage("Invalid AnimeId");
        }


        protected void ValidateDuration()
        {
            RuleFor(c => c.AnimeId)
                .GreaterThan(0).WithMessage("Invalid Duration");
        }

        protected void ValidateEpisodeNumber()
        {
            RuleFor(c => c.EpisodeNumber)
                .GreaterThan(0).WithMessage("Invalid EpisodeNumber");
        }
    }
}
