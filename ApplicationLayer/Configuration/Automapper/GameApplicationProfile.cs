using ApplicationLayer.DTO;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.ValueObjects;

namespace PlayersAPI.Configuration.Automapper
{
    public class GameApplicationProfile : Profile
    {
        public GameApplicationProfile()
        {
            CreateMap<DomainLayer.Entities.Game, GameDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.VideoGameId, o => o.MapFrom(src => src.VideoGameId))
                .ForMember(d => d.PlayerId, o => o.MapFrom(src => src.PlayerId))
                .ForMember(d => d.Points, o => o.MapFrom(src => src.Points))
                .ForMember(d => d.TimePlayed, o => o.MapFrom(src => src.TimePlayed));
        }
    }
}
