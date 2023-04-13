using Selfdoctor.Application.Dtos.HepatitisDiagnostic;

namespace SelfDoctor.ViewModels
{
    public class HepatitisDiagnosticViewModel
    {
        public IEnumerable<HepatitisDiagnosticListDto> HepatitisDiagnostics { get; set; }
        public HepatitisDiagnosticRequestDto HepatitisDiagnostic { get; set; } = null!;

        public HepatitisDiagnosticViewModel()
        {
            HepatitisDiagnostics = new List<HepatitisDiagnosticListDto>();
        }
    }
}
