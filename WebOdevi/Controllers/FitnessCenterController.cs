using Microsoft.AspNetCore.Mvc;

namespace WebOdevi.Controllers
{
    public class FitnessCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
