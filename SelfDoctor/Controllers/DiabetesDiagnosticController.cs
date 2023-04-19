using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selfdoctor.Application.Dtos.DiabetesDiagnostic;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Domain.Models;
using Selfdoctor.Infrastructure.Services;
using SelfDoctor.ViewModels;
using System.Security.Claims;

namespace SelfDoctor.Controllers
{
    [Authorize]
    public class DiabetesDiagnosticController : Controller
    {

        private readonly IDiabetesDiagnosticService _diabetesDiagnosticService;

        public DiabetesDiagnosticController(IDiabetesDiagnosticService diabetesDiagnosticService)
        {
            _diabetesDiagnosticService = diabetesDiagnosticService;
        }

        public async Task<IActionResult> Index(int id = 0)
        {
            var viewModel = new DiabetesDiagnosticViewModel();
            try
            {
                if (TempData["Prediction"] != null)
                    ViewBag.Prediction = TempData["Prediction"];

                if (id != 0)
                    viewModel.DiabetesDiagnostic = await _diabetesDiagnosticService.GetDiabetesDiagnosticByIdAsync(id);

                viewModel.DiabetesDiagnostics = await GetDiagnosticsAsync();
            }
            catch(Exception ex) 
            {
                ViewBag.PredictionError = ex.Message;
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DiabetesDiagnosticRequestDto diabetesDiagnostic)
        {
            var viewModel = new DiabetesDiagnosticViewModel();
            try
            {
                diabetesDiagnostic.UserId = GetUserId();
                var result = await _diabetesDiagnosticService.DoDiagnosticAsync(diabetesDiagnostic);
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

            viewModel.DiabetesDiagnostics = await GetDiagnosticsAsync();
            return View(viewModel);
        }

        private async Task<IEnumerable<DiabetesDiagnosticListDto>> GetDiagnosticsAsync()
        {
            var userId = GetUserId();
            var diabetesCDiagnostics = await _diabetesDiagnosticService.GetDiabetesDiagnosticsAsync(userId);
            return diabetesCDiagnostics;
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
                var result = await _diabetesDiagnosticService.DeleteDiagnosticAsync(id);
                if (result)
                    return RedirectToAction(nameof(Index), new { id = 0 });
            }
            catch (Exception ex)
            {
                ViewBag.PredictionError = ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> GetLastDiabetesDiagnostic()
        {
            var lastDiabetesDiagnostic = await _diabetesDiagnosticService.GetLastDiabetesDiagnostic();
            return Json(lastDiabetesDiagnostic);
        }
    }
}
