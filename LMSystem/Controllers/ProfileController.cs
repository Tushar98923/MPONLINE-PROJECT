using LMSystem.Models;
using LMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    public class ProfileController : Controller
    {
        private readonly LibraryContext _context;

        public ProfileController(LibraryContext context)
        {
            _context = context;
        }

        private async Task<Account?> GetCurrentAccountAsync()
        {
            var accountId = HttpContext.Session.GetInt32("AccountId");
            if (accountId == null) return null;
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public async Task<IActionResult> Index()
        {
            var account = await GetCurrentAccountAsync();
            if (account == null) return RedirectToAction("Index", "Login");
            return View(account);
        }

        public async Task<IActionResult> Edit()
        {
            var account = await GetCurrentAccountAsync();
            if (account == null) return RedirectToAction("Index", "Login");

            return View(new ProfileEditViewModel
            {
                FullName = account.FullName,
                Email = account.Email
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var account = await GetCurrentAccountAsync();
            if (account == null) return RedirectToAction("Index", "Login");

            account.FullName = model.FullName;
            account.Email = model.Email;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Your profile has been updated.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var account = await GetCurrentAccountAsync();
            if (account == null) return RedirectToAction("Index", "Login");

            if (!PasswordHasher.Verify(model.CurrentPassword, account.PasswordHash))
            {
                ModelState.AddModelError(nameof(model.CurrentPassword), "Current password is incorrect.");
                return View(model);
            }

            account.PasswordHash = PasswordHasher.HashPassword(model.NewPassword);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Your password has been changed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
