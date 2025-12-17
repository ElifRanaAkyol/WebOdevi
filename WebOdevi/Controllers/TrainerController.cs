using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Threading.Tasks;
using WebOdevi.Data;
using WebOdevi.Data.Enums;
using WebOdevi.Models;


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

        public async Task<IActionResult> Index() //LINQ sorgusu     
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

            var vm = new TrainerAppointmentVM
            {
                Trainer = trainer,  
                Appointment = new Appointment(),
                TrainerServices = trainer.TrainerServices.ToList()
            };

            ViewBag.DaysOfWeek = Enum.GetValues(typeof(DaysOfWeek))
                .Cast<DaysOfWeek>().ToList()    
                   .Select(d => new SelectListItem
                   {
                       Value = ((int)d).ToString(),
                       Text = d.ToString()
                   }).ToList();

            return View(vm);
        }


        //public IActionResult Create()
        //{
        //    ViewBag.FitnessCenterId = new SelectList(_db.FitnessCenters, "id", "name");
        //    return View();
        //}


        //formu göstermek için (get)
        public IActionResult Create()
        {
            ViewBag.FitnessCenters = new SelectList(_db.FitnessCenters, "Id", "Name");
            ViewBag.Specializations = _db.Specializations.ToList();
            ViewBag.Services = _db.Services.ToList();

            return View();
        }
        //formu post etmek için
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trainer trainer, int[] SelectedSpecializationIds, int[] SelectedServiceIds, List<string> SelectedAvailabilities)
        {
            // Validasyon kontrolü
            if (!ModelState.IsValid)
            {
                ViewBag.FitnessCenters = new SelectList(_db.FitnessCenters, "Id", "Name");
                ViewBag.Specializations = _db.Specializations.ToList();
                ViewBag.Services = _db.Services.ToList();
                return View(trainer);
            }

            try
            {
                if (string.IsNullOrEmpty(trainer.ProfileImageUrl))
                {
                    trainer.ProfileImageUrl = "/images/Trainers/trainer1.png";
                }

                _db.Trainers.Add(trainer);
                await _db.SaveChangesAsync(); 

                if (SelectedSpecializationIds != null)
                {
                    foreach (var sid in SelectedSpecializationIds)
                    {
                        _db.TrainerSpecializations.Add(new TrainerSpecialization
                        {
                            TrainerId = trainer.Id,
                            SpecializationId = sid
                        });
                    }
                }

                if (SelectedServiceIds != null)
                {
                    foreach (var sid in SelectedServiceIds)
                    {
                        _db.TrainerServices.Add(new TrainerService
                        {
                            TrainerId = trainer.Id,
                            ServiceId = sid
                        });
                    }
                }

                if (SelectedAvailabilities != null)
                {
                    foreach (var item in SelectedAvailabilities)
                    {
                        var parts = item.Split('|');
                        if (parts.Length == 2 && Enum.TryParse<DaysOfWeek>(parts[0], out var day))
                        {
                            _db.Availabilities.Add(new Availability
                            {
                                TrainerId = trainer.Id,
                                DayOfWeek = day,
                                Hour = parts[1]
                            });
                        }
                    }
                }

                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "Hata: " + ex.InnerException?.Message ?? ex.Message);

                ViewBag.FitnessCenters = new SelectList(_db.FitnessCenters, "Id", "Name");
                ViewBag.Specializations = _db.Specializations.ToList();
                ViewBag.Services = _db.Services.ToList();
                return View(trainer);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var trainer = await _db.Trainers
                .Include(t => t.TrainerSpecializations)
                .Include(t => t.TrainerServices)
                .Include(t => t.TrainerAvailability)
                .Include(t => t.Appointments)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainer == null)
            {
                return NotFound();
            }

            // bağımlı kayıtları siliyoruz
            if (trainer.TrainerSpecializations != null)
                _db.TrainerSpecializations.RemoveRange(trainer.TrainerSpecializations);

            if (trainer.TrainerServices != null)
                _db.TrainerServices.RemoveRange(trainer.TrainerServices);

            if (trainer.TrainerAvailability != null)
                _db.Availabilities.RemoveRange(trainer.TrainerAvailability);

            if (trainer.Appointments != null)
                _db.Appointments.RemoveRange(trainer.Appointments);

            // eğitmeni sil
            _db.Trainers.Remove(trainer);

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var trainer = await _db.Trainers.FindAsync(id); 
            _db.Trainers.Remove(trainer); 
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var trainer = _db.Trainers
                .Include(t => t.FitnessCenter)
                .FirstOrDefault(t => t.Id == id);

            if (trainer == null)
                return NotFound();

            ViewBag.FitnessCenters =
                new SelectList(_db.FitnessCenters, "Id", "Name", trainer.FitnessCenterId);

            return View(trainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Trainer model)
        {
            if (id != model.Id)
                return NotFound();

            var trainer = await _db.Trainers
                .Include(t => t.FitnessCenter)
                .Include(t => t.TrainerSpecializations)
                .Include(t => t.TrainerServices)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainer == null)
                return NotFound();

            if (!string.IsNullOrWhiteSpace(model.FullName) &&
                trainer.FullName != model.FullName)
            {
                trainer.FullName = model.FullName;
            }

            if (trainer.FitnessCenter != null &&
                model.FitnessCenter != null &&
                !string.IsNullOrWhiteSpace(model.FitnessCenter.Name) &&
                trainer.FitnessCenter.Name != model.FitnessCenter.Name)
            {
                trainer.FitnessCenter.Name = model.FitnessCenter.Name;
            }

            

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
