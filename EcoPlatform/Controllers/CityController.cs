using EcoPlatform.Data;
using EcoPlatform.DTOs.City;
using EcoPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoPlatform.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly EcoPlatformContext _context;
        public CityController(EcoPlatformContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityGetDTO>>> GetCities()
        {
            return await _context.Cities.Include(c => c.Projects).Select(c => new CityGetDTO(c)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityGetDTO>> GetCity(int id)
        {
            var city = await _context.Cities.Include(c => c.Projects).FirstOrDefaultAsync(c => c.Id == id);
            if (city == null)
                return NotFound();

            return new CityGetDTO(city);
        }

        [HttpPost]
        public async Task<ActionResult<CityGetDTO>> CreateCity(CityUpsertDTO city)
        {
            if (city == null)
                return BadRequest("City cannot be null.");

            City c = City.FromDTO(city);

            _context.Cities.Add(c);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCity), new { id = c.Id }, new CityGetDTO(c));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<CityGetDTO>> EditCity(CityUpsertDTO city, int id)
        {
            if (city == null)
                return BadRequest("City cannot be null.");

            var c = await _context.Cities.FindAsync(id);
            
            if (c == null)
                return NotFound();

            c.Name = city.Name;
            c.Region = city.Region;
            c.Country = city.Country;
            c.Latitude = city.Latitude;
            c.Longitude = city.Longitude;

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCity), new { id = c.Id }, new CityGetDTO(c));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
                return NotFound();

            if (await _context.Projects.AnyAsync(p => p.CityId == id))
                return Conflict("Cannot delete city because it has linked projects.");

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
