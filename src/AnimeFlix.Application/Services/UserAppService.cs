using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.UserCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper, IMediatorHandler mediator, IUserRepository userRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var result = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserViewModel>>(result);
        }

        public async Task<UserViewModel> GetById(int id)
        {
            var result = await _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(result);
        }

        public async Task<ValidationResult> Register(UserViewModel viewModel)
        {
            var map = _mapper.Map<RegisterUserCommand>(viewModel);
            var result = await  _mediator.SendCommand<RegisterUserCommand>(map);

            return result;
        }



        public async Task<ValidationResult> Update(UserViewModel viewModel)
        {
            var map = _mapper.Map<UpdateUserCommand>(viewModel);
            var result = await _mediator.SendCommand<UpdateUserCommand>(map);

            return result;
        }

        public async Task<ValidationResult> Remove(int id)
        {
           var command = new DeleteUserCommand(id);
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
