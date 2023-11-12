using AutoMapper;
using DomainLayer.Entities;
using InfraestructureLayer.Models;

namespace InfraestructureLayer.Configuration.Automapper
{
    public class PlayerDAOProfile : Profile
    {
        public PlayerDAOProfile()
        {
            CreateMap<Models.Player, DomainLayer.Entities.Player>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.PlayerId))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.PlayerName))
                .ForMember(d => d.NickName, o => o.MapFrom(src => src.PlayerNickName))
                .ForMember(d => d.Email, o => o.MapFrom(src => src.PlayerEmail));

            CreateMap< DomainLayer.Entities.Player, Models.Player>()
                .ForMember(d => d.PlayerId, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.PlayerName, o => o.MapFrom(src => src.Name))
                .ForMember(d => d.PlayerNickName, o => o.MapFrom(src => src.NickName))
                .ForMember(d => d.PlayerEmail, o => o.MapFrom(src => src.Email));
        }
    }
}
