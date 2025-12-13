using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebOdevi.Data;
using WebOdevi.Models;

namespace WebOdevi.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AppointmentController(ApplicationDbContext db)//kurucu fonksiyon
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()


    }
}
