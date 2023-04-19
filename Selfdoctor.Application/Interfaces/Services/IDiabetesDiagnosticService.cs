using Selfdoctor.Application.Dtos.DiabetesDiagnostic;
using Selfdoctor.Application.Dtos.HepatitisDiagnostic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Interfaces.Services
{
    public interface IDiabetesDiagnosticService
    {
        Task<IEnumerable<DiabetesDiagnosticListDto>> GetDiabetesDiagnosticsAsync(int userId);
        Task<DiabetesDiagnosticRequestDto> GetDiabetesDiagnosticByIdAsync(int DiabetesDiagnosticId);
        Task<string> DoDiagnosticAsync(DiabetesDiagnosticRequestDto diabetesDiagnostic);
        Task<bool> DeleteDiagnosticAsync(int diagnosticId);
        Task<DiabetesDiagnosticListDto> GetLastDiabetesDiagnostic();
    }
}
