using AnimeFlix.Application.ViewModels;
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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new AddressViewModel
                {
                    Id = src.Address.Id,
                    City = src.Address.City,
                    Number = src.Address.Number,
                    Complement = src.Address.Complement,
                    Street = src.Address.Street,
                    ZipCode = src.Address.ZipCode,
                    State = src.Address.State,
                    Country = src.Address.Country
                }));


        }
    }
}

