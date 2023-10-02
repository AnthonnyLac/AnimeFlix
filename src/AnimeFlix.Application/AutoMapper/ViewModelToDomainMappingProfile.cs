using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.CharacterCommand;
using AutoMapper;

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
        }
    }
}
