using Selfdoctor.Application.Dtos.HepatitisDiagnostic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Interfaces.Services
{
    public interface IHepatitisDiagnosticService 
    {
        Task<IEnumerable<HepatitisDiagnosticListDto>> GetHepatitisDiagnosticsAsync(int userId);
        Task<string> DoDiagnosticAsync(HepatitisDiagnosticRequestDto hepatitisDiagnostic);
        Task<bool> DeleteDiagnosticAsync(int diagnosticId);
    }
}
