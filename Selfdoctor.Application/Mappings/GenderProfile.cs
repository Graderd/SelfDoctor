using AutoMapper;
using Selfdoctor.Application.Dtos.Gender;
using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Mappings
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
        }
    }
}
