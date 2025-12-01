using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebOdevi.Data;
using WebOdevi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebOdevi.Controllers
{
    [Authorize(Roles ="Admin")]
    public class TrainerController : Controller
    {
        private readonly ApplicationDbContext _db; //değişkene veri tabanını atadık
        public TrainerController(ApplicationDbContext db)
        {
            _db = db;
        }

        //

        public async Task<IActionResult> Index()
        {
            var trainers = _db.Trainer //veritabanındaki db tablosu
                .Include(t=> t.fitnessCenter)
                .Include(t => t.trainerSpecializations)
                .Include(t => t.trainerServices);

            return View(await trainers.ToListAsync()); //asenkron olmasaydıu kod bu satırda durup sorgunun bitmesini beklerdi
            //asenksonsa thread beklemez başka işler devaö eder. performans artmış olur
        }
        public IActionResult Trainer(int id)
        {
            var trainer = _db.Trainer.FirstOrDefault(t => t.id == id); //verilen koşula ilk uyanı getirir
            return View(trainer);

        }

        //Details view ine gönderir ve htmlden verileri alır
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();

            var trainer = await _db.Trainer
                .Include(t => t.fitnessCenter)
                .Include(t => t.trainerSpecializations)
                    .ThenInclude(ts => ts.specialization)
                .Include(t => t.trainerServices)
                    .ThenInclude(ts => ts.service)
                .Include(t => t.trainerAvailability)
                .Include(t => t.appointments)
                .FirstOrDefaultAsync(t => t.id == id);

            if (trainer == null) return NotFound();

            return View(trainer);
        }


        public IActionResult Create()
        {
            ViewBag.fitnessCenterId = new SelectList(_db.FitnessCenter, "id", "name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _db.Add(trainer);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.fitnessCenterId = new SelectList(_db.FitnessCenter, "id", "name", trainer.fitnessCenterId);
            return View(trainer);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var trainer = await _db.Trainer
                .Include(t => t.trainerServices)
                .Include(t => t.fitnessCenter)
                .FirstOrDefaultAsync(m => m.id == id); //veritabanında id ye göre arama yapar
            if (trainer == null)
            {
                return NotFound();
            }
            return View(trainer);
        }
        [HttpPost, ActionName("Delete")] //aynı isimde iki method olacağı için actionname ile isimlendirdik
        [ValidateAntiForgeryToken] //csrf ataklarına karşı koruma sağlar
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var trainer = await _db.Trainer.FindAsync(id); //id ye göre bulur
            _db.Trainer.Remove(trainer); //veritabanından siler
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
