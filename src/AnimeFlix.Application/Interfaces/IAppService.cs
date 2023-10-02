using AnimeFlix.Application.ViewModels;
using FluentValidation.Results;

namespace AnimeFlix.Application.Interfaces
{
    public interface IAppService<T> : IDisposable where T : ViewModel
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<ValidationResult> Register(T viewModel);
        Task<ValidationResult> Update(T viewModel);
        Task<ValidationResult> Remove(int id);
    }
}
