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

        public DashboardController(IHepatitisDiagnosticService hepatitisDiagnosticService)
        {
            _hepatitisDiagnosticService = hepatitisDiagnosticService;
        }

        public async Task<IActionResult> Index()
        {
            var hepatitisDiagnostics = await _hepatitisDiagnosticService.GetHepatitisDiagnosticsAsync(GetUserId());
            ViewBag.HepatitisDiagnosticsCount = hepatitisDiagnostics.Count();

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
