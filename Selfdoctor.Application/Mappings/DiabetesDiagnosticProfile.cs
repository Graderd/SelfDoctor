using AutoMapper;
using Selfdoctor.Application.Dtos.DiabetesDiagnostic;
using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Mappings
{
    public class DiabetesDiagnosticProfile : Profile
    {
        public DiabetesDiagnosticProfile() 
        {
            CreateMap<DiabetesDiagnostic, DiabetesDiagnosticListDto>().ReverseMap();
            CreateMap<DiabetesDiagnostic, DiabetesDiagnosticRequestDto>().ReverseMap();
        }
    }
}
