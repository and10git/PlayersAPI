using AutoMapper;
using DomainLayer.Entities;
using InfraestructureLayer.Models;

namespace InfraestructureLayer.Configuration.Automapper
{
    public class VideoGameDAOProfile : Profile
    {
        public VideoGameDAOProfile()
        {
            CreateMap<Models.VideoGame, DomainLayer.Entities.VideoGame>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.VideoGameId))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.VideoGameName))
                .ForMember(d => d.Genre, o => o.MapFrom(src => src.VideoGameGenre));

            CreateMap<DomainLayer.Entities.VideoGame, Models.VideoGame>()
                .ForMember(dest => dest.VideoGameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VideoGameName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.VideoGameGenre, opt => opt.MapFrom(src => src.Genre));
        }
    }
}
