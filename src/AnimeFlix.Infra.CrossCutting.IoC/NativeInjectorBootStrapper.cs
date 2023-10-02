using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.Services;
using AnimeFlix.Domain.CommandHandlers;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.CharacterCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
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
            services.AddScoped<IEpisodeAppService, EpisodeAppService>();
            services.AddScoped<IRatingAppService, RatingAppService>();
            services.AddScoped<ICharacterAppService, CharacterAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewAnimeCommand, ValidationResult>, AnimeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAnimeCommand, ValidationResult>, AnimeCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAnimeCommand, ValidationResult>, AnimeCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewCharacterCommand, ValidationResult>, CharacterCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCharacterCommand, ValidationResult>, CharacterCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCharacterCommand, ValidationResult>, CharacterCommandHandler>();

            // Repository
            services.AddScoped<IAnimeRepository, AnimeRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();

        }
    }
}
