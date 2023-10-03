using AnimeFlix.Domain.Commands.RatingCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class RatingCommandHandler: CommandHandler,
        IRequestHandler<RegisterNewRatingCommand, ValidationResult>,
        IRequestHandler<UpdateRatingCommand, ValidationResult>,
        IRequestHandler<DeleteRatingCommand, ValidationResult>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IRatingRepository _ratingRepository;

        public RatingCommandHandler(IAnimeRepository animeRepository, IRatingRepository ratingRepository)
        {
            _animeRepository = animeRepository;
            _ratingRepository = ratingRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewRatingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var anime = await _animeRepository.GetById(request.AnimeId);

                if (anime == null)
                {
                    throw new Exception("Anime Não existe");
                }


                var animeRating = await _ratingRepository.GetByAnimeId(anime.Id);

                if (animeRating != null)
                {
                    throw new Exception("Anime já tem avaliação");
                }

                var ratingModel = new RatingModel(request.AnimeId, request.AverageRating, request.TotalRatings, DateTime.Now);

                _ratingRepository.Add(ratingModel);

                return await Commit(_ratingRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var anime = await _animeRepository.GetById(request.AnimeId);

                if (anime == null)
                {
                    throw new Exception("Anime Não existe");
                }

                var rating = await _ratingRepository.GetById(request.Id);

                if(rating == null)
                {
                    throw new Exception("avaliação não encontrada");
                }

                var animeRating = await _ratingRepository.GetByAnimeId(anime.Id);

                if (animeRating != null && animeRating.Id != rating.Id)
                {
                    throw new Exception("Anime já tem avaliação");
                }

                var ratingModel = new RatingModel(request.AnimeId, request.AverageRating, request.TotalRatings, DateTime.Now);
                ratingModel.SetId(request.Id);

                _ratingRepository.Update(ratingModel);

                return await Commit(_ratingRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var rating = await _ratingRepository.GetById(request.Id);

                if (rating == null)
                {
                    throw new Exception("avaliação não encontrada");
                }

                _ratingRepository.Remove(rating);

                return await Commit(_ratingRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
