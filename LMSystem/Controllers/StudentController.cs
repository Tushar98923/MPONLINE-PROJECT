using LMSystem.Models;
using LMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly LibraryContext _context;

        public StudentController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchTerm, int page = 1)
        {
            var viewModel = new StudentListViewModel
            {
                SearchTerm = searchTerm,
                CurrentPage = page
            };

            var query = _context.Students.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();
                query = query.Where(s =>
                    (s.StudentName != null && s.StudentName.ToLower().Contains(term)) ||
                    (s.Email != null && s.Email.ToLower().Contains(term)) ||
                    (s.Phone != null && s.Phone.ToLower().Contains(term)));
            }

            int totalRecords = await query.CountAsync();
            viewModel.TotalPages = (int)Math.Ceiling(totalRecords / (double)viewModel.PageSize);

            if (viewModel.CurrentPage < 1) viewModel.CurrentPage = 1;
            if (viewModel.CurrentPage > viewModel.TotalPages && viewModel.TotalPages > 0)
            {
                viewModel.CurrentPage = viewModel.TotalPages;
            }

            viewModel.Students = await query
                .OrderBy(s => s.StudentId)
                .Skip((viewModel.CurrentPage - 1) * viewModel.PageSize)
                .Take(viewModel.PageSize)
                .ToListAsync();

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Students.Add(model);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully added student: {model.StudentName}.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return View("NotFound");
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.StudentId == id);
            if (student == null) return View("NotFound");
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student model)
        {
            if (!ModelState.IsValid) return View(model);

            var existing = await _context.Students.FindAsync(id);
            if (existing == null) return View("NotFound");

            existing.StudentName = model.StudentName;
            existing.Email = model.Email;
            existing.Phone = model.Phone;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully updated student: {existing.StudentName}.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return View("NotFound");
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.StudentId == id);
            if (student == null) return View("NotFound");
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return View("NotFound");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Successfully deleted student: {student.StudentName}.";
            return RedirectToAction(nameof(Index));
        }
    }
}
