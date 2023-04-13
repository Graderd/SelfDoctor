using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selfdoctor.Application.Dtos.HepatitisDiagnostic;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Domain.Models;
using SelfDoctor.ViewModels;
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


        public async Task<IActionResult> Index(int id = 0)
        {
            var viewModel = new HepatitisDiagnosticViewModel();
            try
            {
                if (TempData["Prediction"] != null)
                    ViewBag.Prediction = TempData["Prediction"];

                if (id != 0)
                    viewModel.HepatitisDiagnostic = await _hepatitisDiagnosticService.GetHepatitisDiagnosticByIdAsync(id);

                viewModel.HepatitisDiagnostics = await GetDiagnosticsAsync();
            }
            catch (Exception ex)
            {
                ViewBag.PredictionError = ex.Message;
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HepatitisDiagnosticRequestDto hepatitisDiagnostic)
        {
            var viewModel = new HepatitisDiagnosticViewModel();
            try
            {
                hepatitisDiagnostic.UserId = GetUserId();
                var result = await _hepatitisDiagnosticService.DoDiagnosticAsync(hepatitisDiagnostic);
                if (!string.IsNullOrEmpty(result))
                {
                    TempData["Prediction"] = result;
                    return RedirectToAction(nameof(Index), new { id = 0 });
                }
            }
            catch (Exception ex)
            {
                ViewBag.PredictionError = ex.Message;
            }

            viewModel.HepatitisDiagnostics = await GetDiagnosticsAsync();
            return View(viewModel);
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

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();

            try
            {
                var result = await _hepatitisDiagnosticService.DeleteDiagnosticAsync(id);
                if (result)
                    return RedirectToAction(nameof(Index), new { id = 0 });
            }
            catch (Exception ex)
            {
                ViewBag.PredictionError = ex.Message;
            }
            return View();
        }
    }
}
