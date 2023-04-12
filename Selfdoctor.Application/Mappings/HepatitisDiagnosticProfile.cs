using AutoMapper;
using Selfdoctor.Application.Dtos.HepatitisDiagnostic;
using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Mappings
{
    public class HepatitisDiagnosticProfile : Profile
    {
        public HepatitisDiagnosticProfile()
        {
            CreateMap<HepatitiscDiagnostic, HepatitisDiagnosticListDto>().ReverseMap();
            CreateMap<HepatitiscDiagnostic, HepatitisDiagnosticRequestDto>().ReverseMap();
        }
    }
}
