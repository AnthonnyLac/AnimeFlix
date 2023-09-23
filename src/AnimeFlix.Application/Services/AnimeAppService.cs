using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Core.Bus;
using AutoMapper;
using FluentValidation.Results;
using MediatR;

namespace AnimeFlix.Application.Services
{
    public class AnimeAppService : IAnimeAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public AnimeAppService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<IEnumerable<AnimeViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AnimeViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> Register(AnimeViewModel viewModel)
        {
            var command = _mapper.Map<RegisterNewAnimeCommand>(viewModel);
            var result = await _mediator.SendCommand<RegisterNewAnimeCommand>(command);
            
            return result;
        }

        public Task<ValidationResult> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Update(AnimeViewModel viewModel)
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
