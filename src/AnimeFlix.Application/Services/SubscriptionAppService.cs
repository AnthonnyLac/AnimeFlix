using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.SubscriptionCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class SubscriptionAppService : ISubscriptionAppService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;

        public SubscriptionAppService(ISubscriptionRepository subscriptionRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetAll()
        {
            var result = await _subscriptionRepository.GetAll();
            return _mapper.Map<IEnumerable<SubscriptionViewModel>>(result);
        }

        public async Task<SubscriptionViewModel> GetById(int id)
        {
            var result = await _subscriptionRepository.GetById(id);
            return _mapper.Map<SubscriptionViewModel>(result);
        }

        public async Task<ValidationResult> Register(SubscriptionViewModel viewModel)
        {
            var command = _mapper.Map<RegisterSubscriptionCommand>(viewModel);
            var result = await _mediator.SendCommand<RegisterSubscriptionCommand>(command);

            return result;
        }
        public async Task<ValidationResult> Update(SubscriptionViewModel viewModel)
        {
            var command = _mapper.Map<UpdateSubscriptionCommand>(viewModel);
            var result = await _mediator.SendCommand<UpdateSubscriptionCommand>(command);

            return result;
        }
        public async Task<ValidationResult> Remove(int id)
        {
            var command = new DeleteSubscriptionCommand(id);
            var result = await _mediator.SendCommand(command);

            return result;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
