using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.RatingCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class RatingAppService : IRatingAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IRatingRepository _ratingRepository;

        public RatingAppService(IMapper mapper, IMediatorHandler mediator, IRatingRepository ratingRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _ratingRepository = ratingRepository;
        }

        public async Task<IEnumerable<RatingViewModel>> GetAll()
        {
            var result = await _ratingRepository.GetAll();
            return _mapper.Map<IEnumerable<RatingViewModel>>(result);
        }

        public async Task<RatingViewModel> GetById(int id)
        {
            var result = await _ratingRepository.GetById(id);
            return _mapper.Map<RatingViewModel>(result);
        }

        public async Task<ValidationResult> Register(RatingViewModel viewModel)
        {
            var map = _mapper.Map<RegisterNewRatingCommand>(viewModel);
            var result = await  _mediator.SendCommand<RegisterNewRatingCommand>(map);

            return result;
        }



        public async Task<ValidationResult> Update(RatingViewModel viewModel)
        {
            var map = _mapper.Map<UpdateRatingCommand>(viewModel);
            var result = await _mediator.SendCommand<UpdateRatingCommand>(map);

            return result;
        }

        public async Task<ValidationResult> Remove(int id)
        {
           var command = new DeleteRatingCommand(id);
           var result = await _mediator.SendCommand(command);

           return result;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose rolou");
            GC.SuppressFinalize(this);
        }
    }
}
