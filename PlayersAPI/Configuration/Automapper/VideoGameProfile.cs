using ApplicationLayer.DTO;
using AutoMapper;
using PlayersAPI.DTO.PlayerDTO;
using PlayersAPI.DTO.VideoGameDTO;

namespace PlayersAPI.Configuration.Automapper
{
    public class VideoGameProfile : Profile
    {
        public VideoGameProfile()
        {
            CreateMap<VideoGameDTO, VideoGameResponseDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.Name))
                .ForMember(d => d.Genre, o => o.MapFrom(src => src.Genre));
        }
    }
}
