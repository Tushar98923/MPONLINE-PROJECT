using LMSystem.Filters;
using LMSystem.Models;
using LMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    [RequireRole("Admin")]
    public class AccountController : Controller
    {
        private readonly LibraryContext _context;

        public AccountController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchTerm, int page = 1)
        {
            if (page < 1) page = 1;
            int pageSize = 5;

            var query = _context.Accounts.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();
                query = query.Where(a =>
                    a.Username.ToLower().Contains(term) ||
                    a.FullName.ToLower().Contains(term) ||
                    a.Email.ToLower().Contains(term));
            }

            int totalRecords = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            if (page > totalPages && totalPages > 0) page = totalPages;

            var accounts = await query
                .OrderBy(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new AccountListViewModel
            {
                Accounts = accounts,
                SearchTerm = searchTerm,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountCreateViewModel model)
        {
            if (await _context.Accounts.AnyAsync(a => a.Username == model.Username))
            {
                ModelState.AddModelError(nameof(model.Username), "That username is already taken.");
            }

            if (!ModelState.IsValid) return View(model);

            var account = new Account
            {
                Username = model.Username,
                PasswordHash = PasswordHasher.HashPassword(model.Password),
                FullName = model.FullName,
                Email = model.Email,
                Role = model.Role,
                CreatedAt = DateTime.UtcNow
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully created account: {account.Username}.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return View("NotFound");
            var account = await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (account == null) return View("NotFound");

            return View(new AccountEditViewModel
            {
                Id = account.Id,
                Username = account.Username,
                FullName = account.FullName,
                Email = account.Email,
                Role = account.Role
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccountEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Username = (await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id))?.Username ?? model.Username;
                return View(model);
            }

            var existing = await _context.Accounts.FindAsync(id);
            if (existing == null) return View("NotFound");

            existing.FullName = model.FullName;
            existing.Email = model.Email;
            existing.Role = model.Role;

            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                existing.PasswordHash = PasswordHasher.HashPassword(model.NewPassword);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully updated account: {existing.Username}.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return View("NotFound");
            var account = await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (account == null) return View("NotFound");
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return View("NotFound");

            var currentAccountId = HttpContext.Session.GetInt32("AccountId");
            if (currentAccountId == account.Id)
            {
                TempData["ErrorMessage"] = "You can't delete your own account while logged in.";
                return RedirectToAction(nameof(Index));
            }

            if (account.Role == AccountRole.Admin)
            {
                var adminCount = await _context.Accounts.CountAsync(a => a.Role == AccountRole.Admin);
                if (adminCount <= 1)
                {
                    TempData["ErrorMessage"] = "You can't delete the last remaining Admin account.";
                    return RedirectToAction(nameof(Index));
                }
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully deleted account: {account.Username}.";
            return RedirectToAction(nameof(Index));
        }
    }
}
