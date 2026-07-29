using LMSystem.Dtos;
using LMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers.Api
{
    [ApiController]
    [Route("api/auth")]
    public class AuthApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AuthApiController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }
            var role = HttpContext.Session.GetString("Role");
            return Ok(new { username, role });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var match = await _context.Accounts
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (match == null || !PasswordHasher.Verify(request.Password ?? string.Empty, match.PasswordHash))
            {
                return Unauthorized(new { message = "Login failed. Invalid username or password." });
            }

            HttpContext.Session.SetString("Username", match.Username);
            HttpContext.Session.SetString("Role", match.Role.ToString());
            HttpContext.Session.SetInt32("AccountId", match.Id);
            return Ok(new { username = match.Username, role = match.Role.ToString() });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok();
        }
    }
}
