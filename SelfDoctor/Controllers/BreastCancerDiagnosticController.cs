using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Selfdoctor.Application.Dtos.BreastCancerDiagnostic;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Domain.Models;
using Selfdoctor.Infrastructure.Services;
using SelfDoctor.ViewModels;
using System.Security.Claims;

namespace SelfDoctor.Controllers
{
    [Authorize]
    public class BreastCancerDiagnosticController : Controller
    {
        private readonly IBreastCancerDiagnosticService _breastCancerDiagnosticService;

        public BreastCancerDiagnosticController(IBreastCancerDiagnosticService breastCancerDiagnosticService)
        {
            _breastCancerDiagnosticService = breastCancerDiagnosticService;
        }

        public async Task<IActionResult> Index(int id = 0)
        {
            var viewModel = new BreastCancerDiagnosticViewModel();
            try
            {
                if (TempData["Prediction"] != null)
                    ViewBag.Prediction = TempData["Prediction"];
                if (id != 0) 
                    viewModel.BreastCancerDiagnostic = await _breastCancerDiagnosticService.GetBreastCancerDiagnosticByIdAsync(id);

                viewModel.BreastCancerDiagnostics = await GetDiagnosticsAsync();
            }
            catch (Exception ex)
            {
                ViewBag.PredictionError = ex.Message;
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BreastCancerDiagnosticRequestDto breastCancerDiagnostic)
        {
            var viewModel = new BreastCancerDiagnosticViewModel();
            try
            {
                breastCancerDiagnostic.UserId = GetUserId();
                var result = await _breastCancerDiagnosticService.DoDiagnosticAsync(breastCancerDiagnostic);
                if(!string.IsNullOrEmpty(result))
                {
                    TempData["Prediction"] = result;
                    return RedirectToAction(nameof(Index), new { id = 0 });
                }
            }
            catch (Exception ex)
            {
                ViewBag.PredictionError = ex.Message;
            }
            viewModel.BreastCancerDiagnostics = await GetDiagnosticsAsync();
            return View(viewModel);
        }

        private async Task<IEnumerable<BreastCancerDiagnosticListDto>> GetDiagnosticsAsync()
        {
            var userId = GetUserId();
            var breasCancerDiagnostics = await _breastCancerDiagnosticService.GetBreastCancerDiagnosticListAsync(userId);
            return breasCancerDiagnostics;
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
                var result = await _breastCancerDiagnosticService.DeleteDiagnosticAsync(id);
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
