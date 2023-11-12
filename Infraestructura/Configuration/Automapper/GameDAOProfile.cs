using AutoMapper;
using DomainLayer.Entities;
using InfraestructureLayer.Models;

namespace InfraestructureLayer.Configuration.Automapper
{
    public class GameDAOProfile : Profile
    {
        public GameDAOProfile()
        {
            CreateMap<Models.Game, DomainLayer.Entities.Game>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.GameId))
                .ForMember(d => d.VideoGameId, o => o.MapFrom(src => src.VideoGameId))
                .ForMember(d => d.PlayerId, o => o.MapFrom(src => src.PlayerId))
                .ForMember(d => d.Points, o => o.MapFrom(src => src.GamePoints))
                .ForMember(d => d.TimePlayed, o => o.MapFrom(src => src.GameTimePlayed));

            CreateMap<DomainLayer.Entities.Game, Models.Game>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VideoGameId, opt => opt.MapFrom(src => src.VideoGameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId))
                .ForMember(dest => dest.GamePoints, opt => opt.MapFrom(src => src.Points))
                .ForMember(dest => dest.GameTimePlayed, opt => opt.MapFrom(src => src.TimePlayed));
        }
    }
}
