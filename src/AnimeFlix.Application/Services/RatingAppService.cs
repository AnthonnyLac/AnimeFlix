using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class RatingAppService : IRatingAppService
    {
        public Task<IEnumerable<RatingViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RatingViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Register(RatingViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Update(RatingViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose rolou");
            GC.SuppressFinalize(this);
        }
    }
}
