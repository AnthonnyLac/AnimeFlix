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

        protected ValidationResult Commit(string message)
        {
            if(!string.IsNullOrEmpty(message))
            {
                AddError(message);
            }

            return ValidationResult;
        }
    }
}
