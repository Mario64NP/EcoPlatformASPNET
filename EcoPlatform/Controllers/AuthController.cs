using EcoPlatform.Data;
using EcoPlatform.DTOs.Auth;
using EcoPlatform.Models;
using EcoPlatform.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly EcoPlatformContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(EcoPlatformContext context, ITokenService tokenService, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username || u.Email == request.Email);
            if (existingUser != null)
                return BadRequest("Username or email already exists.");

            User user = new()
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = _passwordHasher.HashPassword(null, request.Password),
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid email or password.");

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token, tokenType = "Bearer", expiresIn = 3600 });
        }
    }
}
