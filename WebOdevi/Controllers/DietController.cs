using Microsoft.AspNetCore.Mvc;
using WebOdevi.Models.ViewModels;
using WebOdevi.Services;

namespace WebOdevi.Controllers
{
    public class DietController : Controller
    {
        private readonly OpenAiService _openAiService;

        public DietController(OpenAiService openAiService)
        {
            _openAiService = openAiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateDiet(DietInputViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var prompt = $@"
            Height: {model.Height}
            Weight: {model.Weight}
            Body Type: {model.BodyType}
            Goal: {model.Goal}
            ";

            var dietPlan = await _openAiService.GetDietPlan(prompt);

            ViewBag.DietPlan = dietPlan;
            return View("Index", model);
        }

    }
}
