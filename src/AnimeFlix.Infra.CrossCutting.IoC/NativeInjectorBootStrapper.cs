﻿using AnimeFlix.Application.Interfaces;
using AnimeFlix.Application.Services;
using AnimeFlix.Domain.CommandHandlers;
using AnimeFlix.Domain.Commands.AddressCommand;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.CharacterCommand;
using AnimeFlix.Domain.Commands.EpisodeCommand;
using AnimeFlix.Domain.Commands.PlanCommand;
using AnimeFlix.Domain.Commands.RatingCommand;
using AnimeFlix.Domain.Commands.SubscriptionCommand;
using AnimeFlix.Domain.Commands.UserCommand;
using AnimeFlix.Domain.Core.Bus;
using AnimeFlix.Domain.Core.Data;
using AnimeFlix.Domain.Interfaces;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.User;
using AnimeFlix.Infra.CrossCutting.Bus;
using AnimeFlix.Infra.Data.Context;
using AnimeFlix.Infra.Data.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IAnimeAppService, AnimeAppService>();
            services.AddScoped<IEpisodeAppService, EpisodeAppService>();
            services.AddScoped<IRatingAppService, RatingAppService>();
            services.AddScoped<ICharacterAppService, CharacterAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IPlanAppService, PlanAppService>();
            services.AddScoped<ISubscriptionAppService, SubscriptionAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewAnimeCommand, ValidationResult>, AnimeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAnimeCommand, ValidationResult>, AnimeCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAnimeCommand, ValidationResult>, AnimeCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewCharacterCommand, ValidationResult>, CharacterCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCharacterCommand, ValidationResult>, CharacterCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCharacterCommand, ValidationResult>, CharacterCommandHandler>();

            services.AddScoped<IRequestHandler< RegisterNewEpisodeCommand, ValidationResult >, EpisodeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEpisodeCommand, ValidationResult>, EpisodeCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteEpisodeCommand, ValidationResult>, EpisodeCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewRatingCommand, ValidationResult>, RatingCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateRatingCommand, ValidationResult>, RatingCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteRatingCommand, ValidationResult>, RatingCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, ValidationResult>, UserCommandHandler>();


            services.AddScoped<IRequestHandler<RegisterNewPlanCommand, ValidationResult>, PlanCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePlanCommand, ValidationResult>, PlanCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePlanCommand, ValidationResult>, PlanCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterAddressCommand, ValidationResult>, AddressCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAddressCommand, ValidationResult>, AddressCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAddressCommand, ValidationResult>, AddressCommandHandler>();


            services.AddScoped<IRequestHandler<RegisterSubscriptionCommand, ValidationResult>, SubscriptionCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSubscriptionCommand, ValidationResult>, SubscriptionCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteSubscriptionCommand, ValidationResult>, SubscriptionCommandHandler>();

            // Repository
            services.AddScoped<IAnimeRepository, AnimeRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();


        }
    }
}
