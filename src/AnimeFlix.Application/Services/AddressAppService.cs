using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AddressCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AutoMapper;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IAddressRepository _addressRepository;

        public UserAppService(IMapper mapper, IMediatorHandler mediator, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _addressRepository = addressRepository;
        }


        public async Task<AddressViewModel> GetById(int id)
        {
            var result = await _addressRepository.GetById(id);
            return _mapper.Map<AddressViewModel>(result);
        }

        public async Task<ValidationResult> Register(AddressViewModel viewModel)
        {
            var map = _mapper.Map<RegisterAddressCommand>(viewModel);
            var result = await  _mediator.SendCommand<RegisterAddressCommand>(map);

            return result;
        }



        public async Task<ValidationResult> Update(AddressViewModel viewModel)
        {
            var map = _mapper.Map<UpdateAddressCommand>(viewModel);
            var result = await _mediator.SendCommand<UpdateAddressCommand>(map);

            return result;
        }

        public async Task<ValidationResult> Delete(int id)
        {
           var command = new DeleteAddressCommand(id);
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
