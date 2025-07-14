using EcoPlatform.Data;
using EcoPlatform.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoPlatform.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EcoPlatformContext _context;
        public UserController(EcoPlatformContext context) => _context = context;

        private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string UserRole => User.FindFirstValue(ClaimTypes.Role);

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

        [HttpPut("{id}")]
        public async Task<ActionResult<UserGetDTO>> EditUser(UserUpsertDTO userDto, int id)
        {
            if (userDto == null)
                return BadRequest("User cannot be null.");

            if (UserId != id && UserRole != "Admin")
                return Forbid("You can only edit your own profile.");

            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            user.Username = userDto.Username;
            user.Email = userDto.Email;

            await _context.SaveChangesAsync();

            return Ok(new UserGetDTO(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (UserId != id && UserRole != "Admin")
                return Forbid("You can only delete your own profile.");

            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
