

using Selfdoctor.Application.Dtos.BreastCancerDiagnostic;

namespace SelfDoctor.ViewModels
{
    public class BreastCancerDiagnosticViewModel
    {
        public IEnumerable<BreastCancerDiagnosticListDto> BreastCancerDiagnostics { get; set; }
        public BreastCancerDiagnosticRequestDto BreastCancerDiagnostic { get; set; }
        public BreastCancerDiagnosticViewModel()
        {
            BreastCancerDiagnostics = new List<BreastCancerDiagnosticListDto>();
        }
    }
}
