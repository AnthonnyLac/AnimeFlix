using AnimeFlix.Domain.Commands.AddressCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Address;
using AnimeFlix.Domain.Validations.AddressValidation;
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

        public AddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<ValidationResult> Handle(RegisterAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid()) 
                { 
                    return request.ValidationResult;
                }

                var addressModel = new AddressModel(request.Street, request.City, request.State, request.City, request.Country, request.ZipCode);

                _addressRepository.Add(addressModel);


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

                var address = await _addressRepository.GetById(request.Id);

                if (address == null)
                {
                    throw new Exception("Endereço não encontrado!");
                }

                var addressModel = new AddressModel(request.Street, request.City, request.State, request.City, request.Country, request.ZipCode);
                addressModel.SetId(request.Id);

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
