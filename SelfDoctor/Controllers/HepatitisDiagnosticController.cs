using Microsoft.AspNetCore.Mvc;

namespace SelfDoctor.Controllers
{
    public class HepatitisDiagnosticController : Controller
    {
        public IActionResult CreateDiagnostic()
        {
            return View();
        }
    }
}
