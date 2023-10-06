using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.PlanCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class PlanAppService : IPlanAppService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public PlanAppService(IPlanRepository planRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _planRepository = planRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<PlanViewModel>> GetAll()
        {
            var result = await _planRepository.GetAll();
            return _mapper.Map<IEnumerable<PlanViewModel>>(result);
        }

        public async Task<PlanViewModel> GetById(int id)
        {
            var result = await _planRepository.GetById(id);
            return _mapper.Map<PlanViewModel>(result);
        }

        public async Task<ValidationResult> Register(PlanViewModel viewModel)
        {
            var command = _mapper.Map<RegisterNewPlanCommand>(viewModel);
            var result = await _mediator.SendCommand<RegisterNewPlanCommand>(command);

            return result;
        }
        public async Task<ValidationResult> Update(PlanViewModel viewModel)
        {
            var command = _mapper.Map<UpdatePlanCommand>(viewModel);
            var result = await _mediator.SendCommand<UpdatePlanCommand>(command);

            return result;
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var command = new DeletePlanCommand(id);
            var result = await _mediator.SendCommand<DeletePlanCommand>(command);

            return result;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
