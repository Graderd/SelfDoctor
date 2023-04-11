using Microsoft.AspNetCore.Mvc;

namespace SelfDoctor.Controllers
{
    public class CancerDiagnosticController : Controller
    {
        public IActionResult CreateDiagnostic()
        {
            return View();
        }
    }
}
