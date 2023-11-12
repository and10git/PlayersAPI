using ApplicationLayer.DTO;
using AutoMapper;
using PlayersAPI.DTO.GameDTO;
using PlayersAPI.DTO.PlayerDTO;

namespace PlayersAPI.Configuration.Automapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDTO, GameResponseDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.VideoGameId, o => o.MapFrom(src => src.VideoGameId))
                .ForMember(d => d.PlayerId, o => o.MapFrom(src => src.PlayerId))
                .ForMember(d => d.Points, o => o.MapFrom(src => src.Points))
                .ForMember(d => d.TimePlayed, o => o.MapFrom(src => src.TimePlayed));
        }
    }
}
