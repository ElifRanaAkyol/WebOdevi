using Microsoft.AspNetCore.Mvc;
using WebOdevi.Models.ViewModels;

public class DietController : Controller
{
    private readonly GroqService _groqService;

    public DietController(GroqService groqService)
    {
        _groqService = groqService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GenerateDiet(DietInputViewModel model)
    {
        if (ModelState.IsValid)
        {
            // API'ye gönderilecek komutu hazırlıyoruz
            string prompt = $"Boyum {model.Height} cm, kilom {model.Weight} kg. Vücut tipim {model.BodyType} ve hedefim {model.Goal}. " +
                            "Bana uygun 1 günlük örnek beslenme listesi ve yapmam gereken temel egzersizleri söyler misin?";

            try
            {
                var result = await _groqService.GetAiResponse(prompt);
                ViewBag.DietPlan = result; // View'daki ViewBag.DietPlan'a veriyi gönderiyoruz
            }
            catch (Exception ex)
            {
                ViewBag.DietPlan = "Hata Detayı: " + ex.Message;
            }
        }

        return View("Index", model);
    }
}