using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.CharacterCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class CharacterAppService : ICharacterAppService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public CharacterAppService(ICharacterRepository characterRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CharacterViewModel>> GetAll()
        {
            var result = await _characterRepository.GetAll();
            return _mapper.Map<IEnumerable<CharacterViewModel>>(result);
        }

        public async Task<CharacterViewModel> GetById(int id)
        {
            var result = await _characterRepository.GetById(id);
            return _mapper.Map<CharacterViewModel>(result);
        }

        public Task<ValidationResult> Register(CharacterViewModel viewModel)
        {
            var map = _mapper.Map<RegisterNewCharacterCommand>(viewModel);
            return _mediator.SendCommand<RegisterNewCharacterCommand>(map) ;
        }

        public Task<ValidationResult> Remove(int id)
        {
            var command = new DeleteCharacterCommand(id);
            return _mediator.SendCommand<DeleteCharacterCommand>(command);
        }

        public Task<ValidationResult> Update(CharacterViewModel viewModel)
        {
            var map = _mapper.Map<UpdateCharacterCommand>(viewModel);
            return _mediator.SendCommand<UpdateCharacterCommand>(map);
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose rolou");
            GC.SuppressFinalize(this);
        }

    }
}
