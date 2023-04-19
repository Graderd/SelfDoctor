using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Infrastructure.Services;
using System.Security.Claims;

namespace SelfDoctor.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IHepatitisDiagnosticService _hepatitisDiagnosticService;
		private readonly IBreastCancerDiagnosticService _breastCancerDiagnosticService;
		private readonly IDiabetesDiagnosticService _diabetesDiagnosticService;

		public DashboardController(IHepatitisDiagnosticService hepatitisDiagnosticService, IBreastCancerDiagnosticService breastCancerDiagnosticService, IDiabetesDiagnosticService diabetesDiagnosticService)
        {
            _hepatitisDiagnosticService = hepatitisDiagnosticService;
            _breastCancerDiagnosticService = breastCancerDiagnosticService;
            _diabetesDiagnosticService = diabetesDiagnosticService;
        }

        public async Task<IActionResult> Index()
        {
            var hepatitisDiagnostics = await _hepatitisDiagnosticService.GetHepatitisDiagnosticsAsync(GetUserId());
            ViewBag.HepatitisDiagnosticsCount = hepatitisDiagnostics.Count();

            var breastDiagnostics = await _breastCancerDiagnosticService.GetBreastCancerDiagnosticListAsync(GetUserId());
            ViewBag.BreastCancerDiagnosticsCount = breastDiagnostics.Count();

            var diabetesDiagnostics = await _diabetesDiagnosticService.GetDiabetesDiagnosticsAsync(GetUserId());
            ViewBag.DiabetesDiagnosticsCount = diabetesDiagnostics.Count();

            return View();
        }

        private int GetUserId()
        {
            var userIdClaim = HttpContext.User.Claims.Where(c => c.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault();
            int.TryParse(userIdClaim?.Value, out int userId);
            return userId;
        }


       
    }
}
