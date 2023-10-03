using AnimeFlix.Domain.Commands.EpisodeCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class EpisodeCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewEpisodeCommand, ValidationResult>,
        IRequestHandler<UpdateEpisodeCommand, ValidationResult>,
        IRequestHandler<DeleteEpisodeCommand, ValidationResult>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeCommandHandler(IAnimeRepository animeRepository, IEpisodeRepository episodeRepository)
        {
            _animeRepository = animeRepository;
            _episodeRepository = episodeRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewEpisodeCommand request, CancellationToken cancellationToken)
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

                var episodeModel = new EpisodeModel(request.EpisodeNumber, request.Title, request.Description, request.VideoUrl, request.Duration, request.AnimeId);

                _episodeRepository.Add(episodeModel);


                return await Commit(_episodeRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(UpdateEpisodeCommand request, CancellationToken cancellationToken)
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

                var episode = await _episodeRepository.GetById(request.Id);

                if(episode == null)
                {
                    throw new Exception("episodio Não existe");
                }

                var episodeModel = new EpisodeModel(request.EpisodeNumber, request.Title, request.Description, request.VideoUrl, request.Duration, request.AnimeId);
                episodeModel.SetId(episode.Id);


                _episodeRepository.Update(episodeModel);


                return await Commit(_episodeRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(DeleteEpisodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var episode = await _episodeRepository.GetById(request.Id);

                if (episode == null)
                {
                    throw new Exception("episodio Não existe");
                }

                var episodeModel = new EpisodeModel(request.EpisodeNumber, request.Title, request.Description, request.VideoUrl, request.Duration, request.AnimeId);
                episodeModel.SetId(episode.Id);


                _episodeRepository.Remove(episodeModel);

                return await Commit(_episodeRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
