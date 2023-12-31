﻿using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.CharacterCommand;
using AnimeFlix.Domain.Commands.EpisodeCommand;
using AnimeFlix.Domain.Commands.PlanCommand;
using AnimeFlix.Domain.Commands.RatingCommand;
using AnimeFlix.Domain.Commands.UserCommand;
using AnimeFlix.Domain.Commands.AddressCommand;
using AnimeFlix.Domain.Models.Anime;
using AutoMapper;
using AnimeFlix.Domain.Commands.SubscriptionCommand;

namespace AnimeFlix.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AnimeViewModel, RegisterNewAnimeCommand>()
                .ConstructUsing(c => new RegisterNewAnimeCommand(c.Title, c.Description, c.Genre, c.ReleaseYear, c.CoverImage, c.Trailer));

            CreateMap<AnimeViewModel, UpdateAnimeCommand>()
                .ConstructUsing(c => new UpdateAnimeCommand(c.Id, c.Title, c.Description, c.Genre, c.ReleaseYear, c.CoverImage, c.Trailer));


            CreateMap<CharacterViewModel, RegisterNewCharacterCommand>()
                .ConstructUsing(c => new RegisterNewCharacterCommand(c.Name, c.Description, c.ImageUrl, c.AnimeId));


            CreateMap<CharacterViewModel, UpdateCharacterCommand>()
                .ConstructUsing(c => new UpdateCharacterCommand(c.Id, c.Name, c.Description, c.ImageUrl, c.AnimeId));

            CreateMap<EpisodeViewModel, RegisterNewEpisodeCommand>()
                .ConstructUsing(c => new RegisterNewEpisodeCommand(c.EpisodeNumber,c.Title,c.Description,c.VideoUrl,c.Duration,c.AnimeId));


            CreateMap<EpisodeViewModel, UpdateEpisodeCommand>()
                .ConstructUsing(c => new UpdateEpisodeCommand(c.Id, c.EpisodeNumber, c.Title, c.Description, c.VideoUrl, c.Duration, c.AnimeId));

            CreateMap<RatingViewModel, RegisterNewRatingCommand>()
                .ConstructUsing(c => new RegisterNewRatingCommand(c.AnimeId, c.AverageRating,c.TotalRatings));

            CreateMap<RatingViewModel, UpdateRatingCommand>()
                .ConstructUsing(c => new UpdateRatingCommand(c.Id, c.AnimeId, c.AverageRating, c.TotalRatings));
                

            CreateMap<UserViewModel, RegisterUserCommand>()
                .ConstructUsing(c => new RegisterUserCommand(c.Name, c.Bio, c.Email, c.Phone, c.Address.Street, c.Address.Number, c.Address.Complement, c.Address.City, c.Address.State, c.Address.Country, c.Address.ZipCode));

            CreateMap<UserViewModel, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id, c.Name, c.Bio, c.Email, c.Phone, c.Address.Id, c.Address.Street, c.Address.Number, c.Address.Complement, c.Address.City, c.Address.State, c.Address.Country, c.Address.ZipCode));


            CreateMap<PlanViewModel, RegisterNewPlanCommand>()
                .ConstructUsing(c => new RegisterNewPlanCommand(c.Name,c.Description,c.Price,c.DurationInDays,c.IsActive));

            CreateMap<PlanViewModel, UpdatePlanCommand>()
                .ConstructUsing(c => new UpdatePlanCommand(c.Id, c.Name, c.Description, c.Price, c.DurationInDays, c.IsActive));


            CreateMap<AddressViewModel, RegisterAddressCommand>()
                .ConstructUsing(c => new RegisterAddressCommand(c.Street, c.Number, c.Complement, c.City, c.State, c.Country, c.ZipCode, c.UserId));

            CreateMap<AddressViewModel, UpdateAddressCommand>()
                .ConstructUsing(c => new UpdateAddressCommand(c.Street, c.Number, c.Complement, c.City, c.State, c.Country, c.ZipCode, c.UserId));


            CreateMap<SubscriptionViewModel, RegisterSubscriptionCommand>()
                .ConstructUsing(c => new RegisterSubscriptionCommand(c.UserId,c.PlanId));

            CreateMap<SubscriptionViewModel, UpdateSubscriptionCommand>()
                .ConstructUsing(c => new UpdateSubscriptionCommand(c.Id, c.UserId, c.PlanId));

        }
    }
}
