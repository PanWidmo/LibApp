using AutoMapper;
using LibApp.Dtos;
using LibApp.Models;

namespace LibApp.Profiles
{
    public class RoleTypeProfile : Profile
    {
        public RoleTypeProfile()
        {
            CreateMap<RoleType, RoleTypeDto>();
            CreateMap<RoleTypeDto, RoleType>();

        }

    }
}
