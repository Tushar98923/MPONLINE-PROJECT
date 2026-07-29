using LMSystem.Models;
using LMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly LibraryContext _context;

        public DashboardController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var totalBooks = await _context.Books.CountAsync();
            var availableBooks = await _context.Books.CountAsync(b => b.IsAvailable);
            var totalBorrowRecords = await _context.BorrowRecords.CountAsync();
            var returnedBorrows = await _context.BorrowRecords.CountAsync(r => r.ReturnDate != null);

            var borrowsPerBook = await _context.BorrowRecords
                .Include(r => r.Book)
                .GroupBy(r => r.Book!.Title)
                .Select(g => new BookBorrowCount { Title = g.Key!, Count = g.Count() })
                .OrderByDescending(c => c.Count)
                .ToListAsync();

            var model = new DashboardViewModel
            {
                TotalBooks = totalBooks,
                AvailableBooks = availableBooks,
                TotalStudents = await _context.Students.CountAsync(),
                TotalLibrarians = await _context.Librarians.CountAsync(),
                TotalBorrowings = await _context.BorrowRecords.CountAsync(r => r.ReturnDate == null),
                TotalBorrowRecords = totalBorrowRecords,
                ReturnedBorrows = returnedBorrows,
                TotalPublications = await _context.Publications.CountAsync(),
                TotalNewspapers = await _context.Publications.CountAsync(p => p.Type == PublicationType.Newspaper),
                TotalMagazines = await _context.Publications.CountAsync(p => p.Type == PublicationType.Magazine),
                BorrowsPerBook = borrowsPerBook
            };

            return View(model);
        }
    }
}
