using LMSystem.Models;
using LMSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    public class BorrowController : Controller
    {
        private readonly LibraryContext _context;

        public BorrowController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(int? bookId)
        {
            if (bookId == null || bookId == 0) return View("NotFound");

            var book = await _context.Books.FindAsync(bookId);
            if (book == null) return View("NotFound");
            if (!book.IsAvailable) return View("NotAvailable");

            var model = new BorrowViewModel { BookId = book.BookId, BookTitle = book.Title };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowViewModel model)
        {
            var book = await _context.Books.FindAsync(model.BookId);
            if (book == null) return View("NotFound");
            if (!book.IsAvailable) return View("NotAvailable");

            if (!ModelState.IsValid)
            {
                model.BookTitle = book.Title;
                return View(model);
            }

            var borrowRecord = new BorrowRecord
            {
                BookId = book.BookId,
                BorrowerName = model.BorrowerName,
                BorrowerEmail = model.BorrowerEmail,
                Phone = model.Phone,
                BorrowDate = DateTime.UtcNow
            };
            book.IsAvailable = false;

            _context.BorrowRecords.Add(borrowRecord);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"You have borrowed \"{book.Title}\".";
            return RedirectToAction("Index", "Books");
        }

        public async Task<IActionResult> Return(int? borrowRecordId)
        {
            if (borrowRecordId == null || borrowRecordId == 0) return View("NotFound");

            var borrowRecord = await _context.BorrowRecords
                .Include(br => br.Book)
                .FirstOrDefaultAsync(br => br.BorrowRecordId == borrowRecordId);

            if (borrowRecord == null) return View("NotFound");
            if (borrowRecord.ReturnDate != null) return View("AlreadyReturned");

            var model = new ReturnViewModel
            {
                BorrowRecordId = borrowRecord.BorrowRecordId,
                BookTitle = borrowRecord.Book?.Title,
                BorrowerName = borrowRecord.BorrowerName,
                BorrowDate = borrowRecord.BorrowDate
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(ReturnViewModel model)
        {
            var borrowRecord = await _context.BorrowRecords
                .Include(br => br.Book)
                .FirstOrDefaultAsync(br => br.BorrowRecordId == model.BorrowRecordId);

            if (borrowRecord == null) return View("NotFound");
            if (borrowRecord.ReturnDate != null) return View("AlreadyReturned");

            borrowRecord.ReturnDate = DateTime.UtcNow;
            if (borrowRecord.Book != null) borrowRecord.Book.IsAvailable = true;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Book returned successfully.";
            return RedirectToAction("Index", "Books");
        }
    }
}
