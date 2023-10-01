using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Enum;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class AnimeCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewAnimeCommand, ValidationResult>
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeCommandHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewAnimeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid()) 
                { 
                    return request.ValidationResult;
                }

                var anime = await _animeRepository.GetByName(request.Title);

                if (anime != null)
                {
                    throw new Exception("O anime já existe");
                }

                var animeModel = new AnimeModel(request.Title, request.Description, (AnimeCetegory)request.Genre, request.ReleaseYear, request.CoverImage, request.Trailer);

                _animeRepository.Add(animeModel);
 

                return await Commit(_animeRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
