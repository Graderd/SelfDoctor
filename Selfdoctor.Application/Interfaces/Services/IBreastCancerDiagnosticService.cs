using Selfdoctor.Application.Dtos.BreastCancerDiagnostic;

using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Interfaces.Services
{
    public interface IBreastCancerDiagnosticService
    {
        Task<IEnumerable<BreastCancerDiagnosticListDto>> GetBreastCancerDiagnosticListAsync(int userId);
        Task<BreastCancerDiagnosticRequestDto> GetBreastCancerDiagnosticByIdAsync(int BreastCancerDiagnosticId);
        Task<string> DoDiagnosticAsync(BreastCancerDiagnosticRequestDto breastCancerDiagnostic);
        Task<bool> DeleteDiagnosticAsync(int diagnosticId);
        Task<BreastCancerDiagnosticListDto> GetLastBreastCancerDiagnostic();

    }
}
