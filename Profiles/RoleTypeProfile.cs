using AutoMapper;
using LibApp.Dtos;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
