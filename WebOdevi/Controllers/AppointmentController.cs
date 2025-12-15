using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using WebOdevi.Data.Enums;
using WebOdevi.Data;
using WebOdevi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace WebOdevi.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        public AppointmentController(ApplicationDbContext db, UserManager<User> userManager)//kurucu fonksiyon
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int trainerId)
        {
            var trainer = _db.Trainers
                .Include(t => t.TrainerServices)
                    .ThenInclude(ts => ts.Service)
                .FirstOrDefault(t => t.Id == trainerId);

            if (trainer == null)
                return NotFound();

            var vm = new TrainerAppointmentVM
            {
                Trainer = trainer,
                Appointment = new Appointment(),  // boş appointment nesnesi
                TrainerServices = trainer.TrainerServices.ToList()
            };

            ViewBag.DaysOfWeek = Enum.GetValues(typeof(DaysOfWeek))
                .Cast<DaysOfWeek>()
                .Select(d => new SelectListItem
                {
                    Value = ((int)d).ToString(),
                    Text = d.ToString()
                }).ToList();

            return View(vm);  // işte model burada gönderiliyor
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainerAppointmentVM model)
        {
            if (!ModelState.IsValid)
            {
                // ViewBag doldur
                ViewBag.DayOfWeek = Enum.GetValues(typeof(DaysOfWeek)).Cast<DaysOfWeek>().ToList();
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            // Randevu kontrolü
            bool exists = _db.Appointments.Any(a =>
                a.TrainerId == model.Appointment.TrainerId &&
                a.DayOfWeek == model.Appointment.DayOfWeek &&
                a.Hour == model.Appointment.Hour &&
                a.Status != AppointmentStatus.Cancelled);

            if (exists)
            {
                ModelState.AddModelError("", "Bu saatte eğitmen dolu!");
                ViewBag.DayOfWeek = Enum.GetValues(typeof(DaysOfWeek)).Cast<DaysOfWeek>().ToList();
                return View(model);
            }

            model.Appointment.UserId = user.Id;
            model.Appointment.Status = AppointmentStatus.Pending;

            _db.Appointments.Add(model.Appointment);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }


    }
}