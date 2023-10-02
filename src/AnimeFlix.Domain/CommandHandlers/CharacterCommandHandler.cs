using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.CharacterCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Enum;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class CharacterCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCharacterCommand, ValidationResult>,
        IRequestHandler<UpdateCharacterCommand, ValidationResult>,     
        IRequestHandler<DeleteCharacterCommand, ValidationResult>        
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IAnimeRepository _animeRepository;

        public CharacterCommandHandler(ICharacterRepository characterRepository, IAnimeRepository animeRepository)
        {
            _characterRepository = characterRepository;
            _animeRepository = animeRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewCharacterCommand request, CancellationToken cancellationToken)
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

                var character = await _characterRepository.GetCharacterByName(request.Name);

                if (character != null)
                {
                    throw new Exception("O personagem já existe");
                }

                var characterModel = new CharacterModel(request.Name, request.Description, request.ImageUrl, request.AnimeId);

                _characterRepository.Add(characterModel);


                return await Commit(_characterRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
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

                var character = await _characterRepository.GetCharacterByName(request.Name);

                if (character != null && character.Id != request.Id)
                {
                    throw new Exception("O personagem já existe");
                }

                var characterModel = new CharacterModel(request.Name, request.Description, request.ImageUrl, request.AnimeId);
                characterModel.SetId(request.Id);

                _characterRepository.Update(characterModel);


                return await Commit(_characterRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var character = await _characterRepository.GetById(request.Id);

                if (character == null)
                {
                    throw new Exception("Personagem não encontrado");
                }

                _characterRepository.Remove(character);


                return await Commit(_characterRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
