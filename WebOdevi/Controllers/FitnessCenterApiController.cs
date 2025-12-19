using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOdevi.Data;

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
    public async Task<IActionResult> SearchFitnessCenters(string? serviceType)
    {
        var query = _db.FitnessCenters.Include(fc => fc.Services).AsQueryable();

        if (!string.IsNullOrEmpty(serviceType))
        {
            query = query.Where(fc => fc.Services.Any(s => s.Name.Contains(serviceType)));
        }

        var fitnessCenters = await query.ToListAsync();

        return Ok(fitnessCenters.Select(fc => new {
            fc.Id,
            fc.Name,
            fc.Address,
            Services = fc.Services.Select(s => s.Name).ToList()
        }));
    }
}