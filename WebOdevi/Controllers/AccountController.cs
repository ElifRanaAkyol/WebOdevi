using Microsoft.AspNetCore.Mvc;

namespace WebOdevi.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
