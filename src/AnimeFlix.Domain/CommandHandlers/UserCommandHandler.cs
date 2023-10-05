using AnimeFlix.Domain.Commands.UserCommand;
using AnimeFlix.Domain.Core.Commands;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.User;
using AnimeFlix.Domain.Validations.UserValidation;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterUserCommand, ValidationResult>,
        IRequestHandler<UpdateUserCommand, ValidationResult>,
        IRequestHandler<DeleteUserCommand, ValidationResult>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ValidationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid()) 
                { 
                    return request.ValidationResult;
                }

                var user = await _userRepository.GetByName(request.Name);

                if (user != null)
                {
                    throw new Exception("O usuário já existe");
                }

                var userModel = new UserModel(request.Name, request.Bio, request.Email, request.Phone);

                _userRepository.Add(userModel);


                return await Commit(_userRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var user = await _userRepository.GetById(request.Id);

                if (user == null)
                {
                    throw new Exception("Usuário não encontrado!");
                }

                var userModel = new UserModel(request.Name, request.Bio, request.Email, request.Phone);
                userModel.SetId(request.Id);

                _userRepository.Update(userModel);

                return await Commit(_userRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }

        public async Task<ValidationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return request.ValidationResult;
                }

                var user = await _userRepository.GetById(request.Id);

                if (user == null)
                {
                    throw new Exception("Usuário não encontrado!");
                }

                _userRepository.Remove(user);

                return await Commit(_userRepository.UnitOfWork);
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
