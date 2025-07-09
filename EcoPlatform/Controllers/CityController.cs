using EcoPlatform.Data;
using EcoPlatform.DTOs.City;
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
        public async Task<ActionResult<IEnumerable<CityGetDTO>>> GetCities()
        {
            return await _context.Cities.Select(c => new CityGetDTO(c)).ToListAsync();
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
    }
}
