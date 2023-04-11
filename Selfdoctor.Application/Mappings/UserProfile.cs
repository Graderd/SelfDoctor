using AutoMapper;
using Selfdoctor.Application.Dtos.User;
using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile() 
        {
            CreateMap<User,UserInsertDto>().ReverseMap();
            CreateMap<User, UserSessionDto>().ReverseMap();
        }

    }
}
