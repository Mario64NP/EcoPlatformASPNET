using EcoPlatform.Data;
using EcoPlatform.DTOs.Project;
using EcoPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly EcoPlatformContext _context;
        public ProjectController(EcoPlatformContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectGetDTO>>> GetProjects()
        {
            return await _context.Projects.Include(p => p.City).Select(p => new ProjectGetDTO(p)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectGetDTO>> GetProject(int id)
        {
            var project = await _context.Projects.Include(p => p.City).FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
                return NotFound();

            return new ProjectGetDTO(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectGetDTO>> CreateProject(ProjectUpsertDTO project)
        {
            if (project == null)
                return BadRequest("Project cannot be null.");

            var city = await _context.Cities.FindAsync(project.CityId);
            if (city == null)
                return BadRequest("Invalid CityId.");

            Project p = Project.FromDTO(project);
            p.City = city;

            _context.Projects.Add(p);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProject), new { id = p.Id }, new ProjectGetDTO(p));
        }
    }
}
