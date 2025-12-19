using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOdevi.Data;
using WebOdevi.Data.Enums;

[Authorize(Roles = "Admin")] // Sadece admin girebilir
public class AdminController : Controller
{
    private readonly ApplicationDbContext _db;

    public AdminController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> AppointmentRequests()
    {
        var requests = await _db.Appointments
            .Include(a => a.User)
            .Include(a => a.Trainer)
            .Include(a => a.Service)
            .Where(a => a.Status == AppointmentStatus.Pending)
            .ToListAsync();

        return View(requests);
    }

    [HttpPost]
    public async Task<IActionResult> Approve(int id)
    {
        var appointment = await _db.Appointments.FindAsync(id);
        if (appointment != null)
        {
            appointment.Status = AppointmentStatus.Confirmed;
            await _db.SaveChangesAsync();
            TempData["Success"] = "Randevu başarıyla onaylandı.";
        }
        return RedirectToAction(nameof(AppointmentRequests));
    }

    // Randevuyu Reddet
    [HttpPost]
    public async Task<IActionResult> Reject(int id)
    {
        var appointment = await _db.Appointments.FindAsync(id);
        if (appointment != null)
        {
            appointment.Status = AppointmentStatus.Cancelled;
            await _db.SaveChangesAsync();
            TempData["Error"] = "Randevu isteği reddedildi.";
        }
        return RedirectToAction(nameof(AppointmentRequests));
    }
}