using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebOdevi.Data;
using WebOdevi.Models;

namespace WebOdevi.Controllers
{
    public class FitnessCenterController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FitnessCenterController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,WorkingHours")] FitnessCenter fitnessCenter)
        {
            if (ModelState.IsValid)
            {
                _db.FitnessCenters.Add(fitnessCenter);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Yeni fitness merkezi başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(fitnessCenter);
        }
    }
}
