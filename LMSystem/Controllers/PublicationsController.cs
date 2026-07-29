using LMSystem.Models;
using LMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly LibraryContext _context;

        public PublicationsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Publications?type=Newspaper|Magazine
        public async Task<IActionResult> Index(string? type, string? searchString, int pageNumber = 1)
        {
            if (!Enum.TryParse<PublicationType>(type, true, out var pubType))
            {
                pubType = PublicationType.Newspaper;
            }

            int pageSize = 5;
            var items = _context.Publications.AsNoTracking().Where(p => p.Type == pubType).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var term = searchString.Trim().ToLower();
                items = items.Where(p =>
                    (p.Title != null && p.Title.ToLower().Contains(term)) ||
                    (p.Publisher != null && p.Publisher.ToLower().Contains(term)));
            }

            var totalItems = await items.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            if (pageNumber < 1) pageNumber = 1;
            if (pageNumber > totalPages && totalPages > 0) pageNumber = totalPages;

            var paginatedList = await items
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new PublicationListViewModel
            {
                Publications = paginatedList,
                Type = pubType,
                SearchString = searchString,
                PageNumber = pageNumber,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        // GET: Publications/Create
        public IActionResult Create(string? type)
        {
            var pub = new Publication();
            if (Enum.TryParse<PublicationType>(type, true, out var pubType))
            {
                pub.Type = pubType;
            }
            return View(pub);
        }

        // POST: Publications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publication publication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publication);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Successfully added: {publication.Title}.";
                return RedirectToAction(nameof(Index), new { type = publication.Type.ToString() });
            }
            return View(publication);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return View("NotFound");
            var publication = await _context.Publications.FindAsync(id);
            if (publication == null) return View("NotFound");
            return View(publication);
        }

        // POST: Publications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Publication publication)
        {
            if (id != publication.Id) return View("NotFound");

            if (ModelState.IsValid)
            {
                _context.Update(publication);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Successfully updated: {publication.Title}.";
                return RedirectToAction(nameof(Index), new { type = publication.Type.ToString() });
            }
            return View(publication);
        }

        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return View("NotFound");
            var publication = await _context.Publications.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null) return View("NotFound");
            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publications.FindAsync(id);
            var type = publication?.Type.ToString() ?? "Newspaper";
            if (publication != null)
            {
                _context.Publications.Remove(publication);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Successfully deleted: {publication.Title}.";
            }
            return RedirectToAction(nameof(Index), new { type });
        }
    }
}
