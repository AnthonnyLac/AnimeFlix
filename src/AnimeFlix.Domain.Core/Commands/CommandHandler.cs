using AnimeFlix.Domain.Core.Data;
using FluentValidation.Results;

namespace AnimeFlix.Domain.Core.Commands
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            if (!(await uow.Commit()))
            {
                AddError("Commit Error");
            }

            return ValidationResult;
        }
    }
}
