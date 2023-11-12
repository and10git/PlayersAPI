using ApplicationLayer.DTO;
using AutoMapper;
using PlayersAPI.DTO.PlayerDTO;

namespace PlayersAPI.Configuration.Automapper
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerDTO, PlayerResponseDTO> ()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.Name))
                .ForMember(d => d.NickName, o => o.MapFrom(src => src.NickName))
                .ForMember(d => d.Email, o => o.MapFrom(src => src.Email._value));
        }
    }
}
