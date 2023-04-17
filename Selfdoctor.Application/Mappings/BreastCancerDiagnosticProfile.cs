using AutoMapper;
using Selfdoctor.Application.Dtos.BreastCancerDiagnostic;
using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Mappings
{
    public class BreastCancerDiagnosticProfile : Profile
    {
        public BreastCancerDiagnosticProfile() 
        {
            CreateMap<BreastCancerDiagnostic, BreastCancerDiagnosticListDto>().ReverseMap();
            CreateMap<BreastCancerDiagnostic, BreastCancerDiagnosticRequestDto>().ReverseMap();
        }
    }
}
