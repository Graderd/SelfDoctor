using Microsoft.AspNetCore.Mvc;

namespace SelfDoctor.Controllers
{
    public class DiabetesDiagnosticController : Controller
    {
        public IActionResult CreateDiagnostic()
        {
            return View();
        }
    }
}
