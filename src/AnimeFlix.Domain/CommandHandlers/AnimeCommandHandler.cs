using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Core.Commands;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Domain.CommandHandlers
{
    public class AnimeCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewAnimeCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegisterNewAnimeCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                if (!request.IsValid()) return request.ValidationResult;

                return ValidationResult;
            }
            catch (Exception ex) 
            {
                AddError(ex.Message);
                return ValidationResult;
            }
        }
    }
}
