using LMSystem.Dtos;
using LMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers.Api
{
    [ApiController]
    [Route("api/borrow")]
    public class BorrowApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BorrowApiController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet("{borrowRecordId:int}")]
        public async Task<IActionResult> Get(int borrowRecordId)
        {
            var record = await _context.BorrowRecords
                .Include(r => r.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.BorrowRecordId == borrowRecordId);

            if (record == null) return NotFound(new { message = "Borrow record not found." });

            return Ok(new
            {
                borrowRecordId = record.BorrowRecordId,
                bookTitle = record.Book?.Title,
                borrowerName = record.BorrowerName,
                borrowDate = record.BorrowDate,
                returnDate = record.ReturnDate
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(BorrowRequest request)
        {
            var book = await _context.Books.FindAsync(request.BookId);
            if (book == null) return NotFound(new { message = "Book not found." });
            if (!book.IsAvailable) return Conflict(new { message = "This book is currently not available." });

            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var borrowRecord = new BorrowRecord
            {
                BookId = book.BookId,
                BorrowerName = request.BorrowerName,
                BorrowerEmail = request.BorrowerEmail,
                Phone = request.Phone,
                BorrowDate = DateTime.UtcNow
            };
            book.IsAvailable = false;

            _context.BorrowRecords.Add(borrowRecord);
            await _context.SaveChangesAsync();

            return Ok(new { borrowRecordId = borrowRecord.BorrowRecordId, bookTitle = book.Title });
        }

        [HttpPost("{borrowRecordId:int}/return")]
        public async Task<IActionResult> Return(int borrowRecordId)
        {
            var record = await _context.BorrowRecords
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.BorrowRecordId == borrowRecordId);

            if (record == null) return NotFound(new { message = "Borrow record not found." });
            if (record.ReturnDate != null) return Conflict(new { message = "This book has already been returned." });

            record.ReturnDate = DateTime.UtcNow;
            if (record.Book != null) record.Book.IsAvailable = true;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Book returned successfully." });
        }
    }
}
