using LMSystem.Models;
using LMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    public class LibrarianController : Controller
    {
        private readonly LibraryContext _context;

        public LibrarianController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchTerm, int page = 1)
        {
            if (page < 1) page = 1;
            int pageSize = 5;

            var query = _context.Librarians.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();
                query = query.Where(l => l.Name != null && l.Name.ToLower().Contains(term));
            }

            int totalRecords = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            if (page > totalPages && totalPages > 0) page = totalPages;

            var librarians = await query
                .OrderBy(l => l.LibrarianId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new LibrarianListViewModel
            {
                Librarians = librarians,
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
        public async Task<IActionResult> Create(Librarian model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Librarians.Add(model);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully added librarian: {model.Name}.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return View("NotFound");
            var librarian = await _context.Librarians.AsNoTracking().FirstOrDefaultAsync(l => l.LibrarianId == id);
            if (librarian == null) return View("NotFound");
            return View(librarian);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Librarian model)
        {
            if (!ModelState.IsValid) return View(model);

            var existing = await _context.Librarians.FindAsync(id);
            if (existing == null) return View("NotFound");

            existing.Name = model.Name;
            existing.Age = model.Age;
            existing.Phone = model.Phone;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully updated librarian: {existing.Name}.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return View("NotFound");
            var librarian = await _context.Librarians.AsNoTracking().FirstOrDefaultAsync(l => l.LibrarianId == id);
            if (librarian == null) return View("NotFound");
            return View(librarian);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);
            if (librarian == null) return View("NotFound");

            _context.Librarians.Remove(librarian);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully deleted librarian: {librarian.Name}.";
            return RedirectToAction(nameof(Index));
        }
    }
}
