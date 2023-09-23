using AnimeFlix.Domain.Core.Commands;
using FluentValidation.Results;

namespace AnimeFlix.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
