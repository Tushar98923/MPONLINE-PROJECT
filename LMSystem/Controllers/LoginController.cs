using LMSystem.Models;
using LMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly LibraryContext _context;

        public LoginController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var match = await _context.Accounts
                .FirstOrDefaultAsync(u => u.Username == model.Username);

            if (match == null || !PasswordHasher.Verify(model.Password ?? string.Empty, match.PasswordHash))
            {
                ViewBag.LoginError = "Login failed. Invalid username or password.";
                return View("Index", model);
            }

            HttpContext.Session.SetString("Username", match.Username);
            HttpContext.Session.SetString("Role", match.Role.ToString());
            HttpContext.Session.SetInt32("AccountId", match.Id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
