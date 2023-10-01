using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Application.Services
{
    public class AnimeAppService : IAnimeAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IAnimeRepository _animeRepository;

        public AnimeAppService(IMapper mapper, IMediatorHandler mediator, IAnimeRepository animeRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _animeRepository = animeRepository;
        }

        public async Task<IEnumerable<AnimeViewModel>> GetAll()
        {
            var result = await _animeRepository.GetAll();
            return _mapper.Map<IEnumerable<AnimeViewModel>>(result);
        }

        public async Task<AnimeViewModel> GetById(int id)
        {
            var result = await _animeRepository.GetById(id);
            return _mapper.Map<AnimeViewModel>(result);
        }

        public async Task<ValidationResult> Register(AnimeViewModel viewModel)
        {

            var command = _mapper.Map<RegisterNewAnimeCommand>(viewModel);
            var result = await _mediator.SendCommand<RegisterNewAnimeCommand>(command);

            return result;
        }
        public async Task<ValidationResult> Update(AnimeViewModel viewModel)
        {
            var command = _mapper.Map<UpdateAnimeCommand>(viewModel);
            var result = await _mediator.SendCommand<UpdateAnimeCommand>(command);

            return result;
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var command = new DeleteAnimeCommand(id);
            return await _mediator.SendCommand<DeleteAnimeCommand>(command);
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose rolou");
            GC.SuppressFinalize(this);
        }
    }
}
