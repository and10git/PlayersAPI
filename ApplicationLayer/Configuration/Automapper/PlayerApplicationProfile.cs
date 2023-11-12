using ApplicationLayer.DTO;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.ValueObjects;

namespace PlayersAPI.Configuration.Automapper
{
    public class PlayerApplicationProfile : Profile
    {
        public PlayerApplicationProfile()
        {
            CreateMap<DomainLayer.Entities.Player, PlayerDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.Name))
                .ForMember(d => d.NickName, o => o.MapFrom(src => src.NickName))
                .ForMember(d => d.Email, o => o.MapFrom(src => src.Email));                      
        }
    }
}
