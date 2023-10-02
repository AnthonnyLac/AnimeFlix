using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using FluentValidation.Results;

namespace AnimeFlix.Application.Services
{
    public class EpisodeAppService : IEpisodeAppService
    {


        public Task<IEnumerable<EpisodeViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EpisodeViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Register(EpisodeViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Update(EpisodeViewModel viewModel)
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
