using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Core.Commands;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
