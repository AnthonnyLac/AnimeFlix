using AnimeFlix.Application.ViewModels;
using AnimeFlix.Domain.Commands.AnimeCommand;
using AnimeFlix.Domain.Commands.UserCommand;
using AnimeFlix.Domain.Models.Anime;
using AnimeFlix.Domain.Models.Character;
using AnimeFlix.Domain.Models.User;
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

            CreateMap<EpisodeModel, EpisodeViewModel>()
                    .ConstructUsing(c => new EpisodeViewModel()
                    {
                        Id = c.Id,
                        EpisodeNumber = c.EpisodeNumber,
                        Title = c.Title,
                        VideoUrl = c.VideoUrl,
                        Duration = c.Duration,
                        AnimeId = c.AnimeId
                    });

            CreateMap<RatingModel, RatingViewModel>()
                    .ConstructUsing(c => new RatingViewModel()
                    {
                        Id = c.Id,
                        AnimeId = c.AnimeId,
                        AverageRating = c.AverageRating,
                        TotalRatings = c.TotalRatings,
                        LastUpdated = c.LastUpdated
                    });

            CreateMap<UserModel, UserViewModel>()
                    .ConstructUsing(c => new UserViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Bio = c.Bio,
                        Email = c.Email,
                        Phone = c.Phone,
                    });
        }
    }
}

