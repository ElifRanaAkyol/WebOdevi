using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOdevi.Data;
using WebOdevi.Models;

[Route("api/[controller]")]
[ApiController]
public class FitnessCenterApiController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public FitnessCenterApiController(ApplicationDbContext context)
    {
        _db = context;
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchFitnessCenters(string? trainerName)
    {
        // Eğitmenleri de içerecek şekilde sorguyu başlatıyoruz
        var query = _db.FitnessCenters
            .Include(fc => fc.Trainers)
            .AsQueryable();

        // Filtreleme: Eğer bir isim girildiyse, o isme sahip eğitmenin çalıştığı salonları getir
        if (!string.IsNullOrEmpty(trainerName))
        {
            query = query.Where(fc => fc.Trainers.Any(t => t.FullName.Contains(trainerName)));
        }

        var fitnessCenters = await query.ToListAsync();

        return Ok(fitnessCenters.Select(fc => new {
            fc.Id,
            fc.Name,
            fc.Address,
            Trainers = fc.Trainers.Select(t => t.FullName).ToList()
        }));

    }

    
}