using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.Services;
using AnimeFlix.Domain.CommandHandlers;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Infra.CrossCutting.Bus;
using AnimeFlix.Infra.Data.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeFlix.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IAnimeAppService, AnimeAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewAnimeCommand, ValidationResult>, AnimeCommandHandler>();

            // Repository
            services.AddScoped<IAnimeRepository, AnimeRepository>();

        }
    }
}
