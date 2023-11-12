using AutoMapper;
using DomainLayer.Entities;
using InfraestructureLayer.Models;

namespace InfraestructureLayer.Configuration.Automapper
{
    public class UserDAOProfile : Profile
    {
        public UserDAOProfile()
        {
            CreateMap<DomainLayer.Entities.User, Models.User>()
                .ForMember(d => d.UserId, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.UserName, o => o.MapFrom(src => src.Name))
                .ForMember(d => d.UserPassword, o => o.MapFrom(src => src.Password));
        }
    }
}
