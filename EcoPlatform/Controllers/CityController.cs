using EcoPlatform.Data;
using EcoPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly EcoPlatformContext _context;
        public CityController(EcoPlatformContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return city;
        }

        [HttpPost]
        public async Task<ActionResult<City>> CreateCity(City city)
        {
            if (city == null)
            {
                return BadRequest("City cannot be null.");
            }
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }
    }
}
