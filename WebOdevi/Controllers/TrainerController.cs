using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebOdevi.Data;
using WebOdevi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebOdevi.Controllers
{

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
            var trainers = _db.Trainers //veritabanındaki db tablosu
                .Include(t=> t.FitnessCenter)
                .Include(t => t.TrainerSpecializations)
                .Include(t => t.TrainerServices);

            return View(await trainers.ToListAsync()); //asenkron olmasaydıu kod bu satırda durup sorgunun bitmesini beklerdi
            //asenksonsa thread beklemez başka işler devaö eder. performans artmış olur
        }
        public IActionResult Trainer(int id)
        {
            var trainer = _db.Trainers.FirstOrDefault(t => t.Id == id); //verilen koşula ilk uyanı getirir
            return View(trainer);

        }

        //Details view ine gönderir ve htmlden verileri alır
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();

            var trainer = await _db.Trainers
                .Include(t => t.FitnessCenter)
                .Include(t => t.TrainerSpecializations)
                    .ThenInclude(ts => ts.Specialization)
                .Include(t => t.TrainerServices)
                    .ThenInclude(ts => ts.Service)
                .Include(t => t.TrainerAvailability)
                .Include(t => t.Appointments)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainer == null) return NotFound();

            return View(trainer);
        }


        //public IActionResult Create()
        //{
        //    ViewBag.FitnessCenterId = new SelectList(_db.FitnessCenters, "id", "name");
        //    return View();
        //}



        public IActionResult Create()
        {
            ViewBag.FitnessCenters = new SelectList(_db.FitnessCenters, "Id", "Name");
            ViewBag.Specializations = _db.Specializations.ToList();
            ViewBag.Services = _db.Services.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Trainer trainer, int[] SelectedSpecializationIds, int[] SelectedServiceIds)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.FitnessCenters = new SelectList(_db.FitnessCenters, "Id", "Name");
                ViewBag.Specializations = _db.Specializations.ToList();
                ViewBag.Services = _db.Services.ToList();
                return View(trainer);
            }

            _db.Trainers.Add(trainer);
            _db.SaveChanges();

            foreach (var sid in SelectedSpecializationIds)
            {
                _db.TrainerSpecializations.Add(new TrainerSpecialization
                {
                    TrainerId = trainer.Id,
                    SpecializationId = sid
                });
            }

            foreach (var sid in SelectedServiceIds)
            {
                _db.TrainerServices.Add(new TrainerService
                {
                    TrainerId = trainer.Id,
                    ServiceId = sid
                });
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var trainer = await _db.Trainers
                .Include(t => t.TrainerServices)
                .Include(t => t.FitnessCenter)
                .FirstOrDefaultAsync(m => m.Id == id); 
            if (trainer == null)
            {
                return NotFound();
            }
            return View(trainer);
        }
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var trainer = await _db.Trainers.FindAsync(id); 
            _db.Trainers.Remove(trainer); 
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
