using AnimeFlix.Domain.Commands.AddressCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.User;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class AddressCommandHandler : CommandHandler,
        IRequestHandler<RegisterAddressCommand, ValidationResult>,
        IRequestHandler<UpdateAddressCommand, ValidationResult>,
        IRequestHandler<DeleteAddressCommand, ValidationResult>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public AddressCommandHandler(IAddressRepository addressRepository, IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        public async Task<ValidationResult> Handle(RegisterAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid()) 
                { 
                    return request.ValidationResult;
                }

                var user = await _userRepository.GetById(request.UserId);

                if (user == null) 
                {
                    throw new InvalidOperationException("User não encontrado");
                }

                var adress = await _addressRepository.GetAdressByUserId(request.UserId);

                if (adress != null)
                {
                    throw new InvalidOperationException("O usuario já tem um endereço");
                }

                var addressModel = new AddressModel(request.Street, request.Number,request.City,request.State,request.Country,request.ZipCode,request.Complement, request.UserId);
                user.SetAddress(addressModel);

                _userRepository.Update(user);


                return await Commit(_addressRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var user = await _userRepository.GetById(request.UserId);

                if (user == null)
                {
                    throw new InvalidOperationException("User não encontrado");
                }


                var address = await _addressRepository.GetById(request.Id);

                if (address == null)
                {
                    throw new Exception("Endereço não encontrado!");
                }

                var addressModel = new AddressModel(request.Street, request.Number, request.City, request.State, request.Country, request.ZipCode,request.Complement, request.UserId);
                addressModel.SetId(request.Id);
                addressModel.SetUser(user);


                _addressRepository.Update(addressModel);

                return await Commit(_addressRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var address = await _addressRepository.GetById(request.Id);

                if (address == null)
                {
                    throw new Exception("Endereço não encontrado!");
                }

                _addressRepository.Remove(address);

                return await Commit(_addressRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
