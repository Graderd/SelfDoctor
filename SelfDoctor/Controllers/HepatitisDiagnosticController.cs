using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selfdoctor.Application.Dtos.HepatitisDiagnostic;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Domain.Models;
using System.Security.Claims;

namespace SelfDoctor.Controllers
{
    [Authorize]
    public class HepatitisDiagnosticController : Controller
    {
        private readonly IHepatitisDiagnosticService _hepatitisDiagnosticService;

        public HepatitisDiagnosticController(IHepatitisDiagnosticService hepatitisDiagnosticService)
        {
            _hepatitisDiagnosticService = hepatitisDiagnosticService;
        }


        public async Task<IActionResult> Index()
        {

            if (TempData["Prediction"] != null) 
                ViewBag.Prediction = TempData["Prediction"];

            var diagnostics = await GetDiagnosticsAsync();
            return View(diagnostics);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HepatitisDiagnosticRequestDto hepatitisDiagnostic)
        {
            try
            {
                hepatitisDiagnostic.UserId = GetUserId();
                var result = await _hepatitisDiagnosticService.DoDiagnosticAsync(hepatitisDiagnostic);
                if (!string.IsNullOrEmpty(result))
                {
                    TempData["Prediction"] = result;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                ViewBag.PredictionError = ex.Message;
            }

            var diagnostics = await GetDiagnosticsAsync();
            return View(diagnostics);
        }

        private async Task<IEnumerable<HepatitisDiagnosticListDto>> GetDiagnosticsAsync()
        {
            var userId = GetUserId();
            var hepatitisCDiagnostics = await _hepatitisDiagnosticService.GetHepatitisDiagnosticsAsync(userId);
            return hepatitisCDiagnostics;
        }

        private int GetUserId()
        {
            var userIdClaim = HttpContext.User.Claims.Where(c => c.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault();
            int.TryParse(userIdClaim?.Value, out int userId);
            return userId;
        }
    }
}
