using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;
using AutoMapper;

namespace AnimeFlix.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AnimeModel, AnimeViewModel>()
                    .ConstructUsing(c => new AnimeViewModel() 
                    {
                        Id = c.Id,
                        Description = c.Description,
                        Genre = (int)c.Genre,
                        ReleaseYear = c.ReleaseYear,
                        CoverImage = c.CoverImage,
                        Trailer = c.Trailer
                    });

            CreateMap<CharacterModel, CharacterViewModel>()
                .ConstructUsing(c => new CharacterViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    AnimeId = c.AnimeId
                });
        }
    }
}
