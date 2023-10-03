using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Enum;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Validations.AnimeValidations;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class AnimeCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewAnimeCommand, ValidationResult>,
        IRequestHandler<UpdateAnimeCommand, ValidationResult>,
        IRequestHandler<DeleteAnimeCommand, ValidationResult>
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

        public async Task<ValidationResult> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var anime = await _animeRepository.GetById(request.Id);

                if (anime == null)
                {
                    throw new Exception("Anime não encontrado!");
                }

                var animeModel = new AnimeModel(request.Title, request.Description, (AnimeCetegory)request.Genre, request.ReleaseYear, request.CoverImage, request.Trailer);
                animeModel.SetId(request.Id);

                _animeRepository.Update(animeModel);

                return await Commit(_animeRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var anime = await _animeRepository.GetById(request.Id);

                if (anime == null)
                {
                    throw new Exception("Anime não encontrado!");
                }

                _animeRepository.Remove(anime);

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
