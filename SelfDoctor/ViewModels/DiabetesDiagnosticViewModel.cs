using Selfdoctor.Application.Dtos.DiabetesDiagnostic;

namespace SelfDoctor.ViewModels
{
    public class DiabetesDiagnosticViewModel
    {
        public IEnumerable<DiabetesDiagnosticListDto> DiabetesDiagnostics { get; set; }
        public DiabetesDiagnosticRequestDto DiabetesDiagnostic { get; set; } = null!;

        public DiabetesDiagnosticViewModel()
        {
            DiabetesDiagnostics = new List<DiabetesDiagnosticListDto>();
        }
    }
}
