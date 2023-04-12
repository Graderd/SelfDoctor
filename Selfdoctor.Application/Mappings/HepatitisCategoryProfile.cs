using AutoMapper;
using Selfdoctor.Application.Dtos.HepatitiscCategory;
using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Mappings
{
    public class HepatitisCategoryProfile : Profile
    {
        public HepatitisCategoryProfile()
        {
            CreateMap<HepatitiscCategory, HepatitiscCategoryDto>().ReverseMap();
        }
    }
}
