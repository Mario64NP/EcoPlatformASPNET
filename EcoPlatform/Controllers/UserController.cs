using EcoPlatform.Data;
using EcoPlatform.DTOs.User;
using EcoPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EcoPlatformContext _context;
        public UserController(EcoPlatformContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetUsers()
        {
            return await _context.Users.Include(u => u.Projects).Select(u => new UserGetDTO(u)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDTO>> GetUser(int id)
        {
            var user = await _context.Users.Include(u => u.Projects).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();

            return new UserGetDTO(user);
        }
    }
}
