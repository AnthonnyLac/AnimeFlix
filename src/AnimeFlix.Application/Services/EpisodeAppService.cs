using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.EpisodeCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class EpisodeAppService : IEpisodeAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeAppService(IMapper mapper, IMediatorHandler mediator, IEpisodeRepository episodeRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _episodeRepository = episodeRepository;
        }

        public async Task<IEnumerable<EpisodeViewModel>> GetAll()
        {
            var result = await _episodeRepository.GetAll();
            return _mapper.Map<IEnumerable<EpisodeViewModel>>(result);
        }

        public async Task<EpisodeViewModel> GetById(int id)
        {
            var result = await _episodeRepository.GetById(id);
            return _mapper.Map<EpisodeViewModel>(result);
        }

        public async Task<ValidationResult> Register(EpisodeViewModel viewModel)
        {
            var map = _mapper.Map<RegisterNewEpisodeCommand>(viewModel);
            var result = await _mediator.SendCommand<RegisterNewEpisodeCommand>(map);

            return result;
        }
        public async Task<ValidationResult> Update(EpisodeViewModel viewModel)
        {
            var map = _mapper.Map<UpdateEpisodeCommand>(viewModel);
            var result = await _mediator.SendCommand<UpdateEpisodeCommand>(map);

            return result;
        }

        public Task<ValidationResult> Remove(int id)
        {
            var command = new DeleteEpisodeCommand(id);
            return _mediator.SendCommand(command);
        }


        public void Dispose()
        {
            Console.WriteLine("Dispose rolou");
            GC.SuppressFinalize(this);
        }
    }
}
