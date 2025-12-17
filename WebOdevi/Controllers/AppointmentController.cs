using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;
using WebOdevi.Data;
using WebOdevi.Data.Enums;
using WebOdevi.Models;

namespace WebOdevi.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AppointmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix = "Appointment")] Appointment appointment, int SelectedServiceId)
        {
            appointment.ServiceId = SelectedServiceId;
            appointment.Status = AppointmentStatus.Pending;
            appointment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ModelState.Remove("Appointment.User");
            ModelState.Remove("Appointment.Trainer");
            ModelState.Remove("Appointment.Service");

            if (ModelState.IsValid)
            {
                try
                {
                    var isTrainerWorking = await _db.Availabilities.AnyAsync(a =>
                        a.TrainerId == appointment.TrainerId &&
                        a.DayOfWeek == appointment.DayOfWeek &&
                        a.Hour == appointment.Hour);

                    if (!isTrainerWorking)
                    {
                        TempData["Error"] = "Eğitmen bu saatte çalışmamaktadır.";
                        return RedirectToAction("Details", "Trainer", new { id = appointment.TrainerId });
                    }

                    var isAlreadyBooked = await _db.Appointments.AnyAsync(a =>
                        a.TrainerId == appointment.TrainerId &&
                        a.DayOfWeek == appointment.DayOfWeek &&
                        a.Hour == appointment.Hour);

                    if (isAlreadyBooked)
                    {
                        TempData["Error"] = "Bu saatte başka birinin randevusu vardır. Lütfen farklı bir saat seçiniz.";
                        return RedirectToAction("Details", "Trainer", new { id = appointment.TrainerId });
                    }

                    _db.Appointments.Add(appointment);
                    await _db.SaveChangesAsync();

                    TempData["Success"] = "Randevunuz başarıyla oluşturuldu!";
                    return RedirectToAction("Details", "Trainer", new { id = appointment.TrainerId });
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Bir hata oluştu: " + ex.Message;
                }
            }

            TempData["Error"] = "Lütfen tüm alanları doldurduğunuzdan emin olun.";
            return RedirectToAction("Details", "Trainer", new { id = appointment.TrainerId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _db.Appointments
                .FirstOrDefaultAsync(a => a.Id == id);

            if(appointment == null)
            {
                return NotFound();
            }
            _db.Appointments.Remove(appointment);
            await _db.SaveChangesAsync();
            return View();
        }
    }
}