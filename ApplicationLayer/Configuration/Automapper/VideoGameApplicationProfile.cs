using ApplicationLayer.DTO;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.ValueObjects;

namespace PlayersAPI.Configuration.Automapper
{
    public class VideoGameApplicationProfile : Profile
    {
        public VideoGameApplicationProfile()
        {
            CreateMap<DomainLayer.Entities.VideoGame, VideoGameDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.Name))
                .ForMember(d => d.Genre, o => o.MapFrom(src => src.Genre));
        }
    }
}
