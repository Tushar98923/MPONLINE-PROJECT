using LMSystem.Dtos;
using LMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers.Api
{
    [ApiController]
    [Route("api/books")]
    public class BooksApiController : ControllerBase
    {
        private readonly LibraryContext _context;
        private const int PageSize = 5;

        public BooksApiController(LibraryContext context)
        {
            _context = context;
        }

        private static BookDto ToDto(Book b, int? activeBorrowRecordId) => new()
        {
            BookId = b.BookId,
            Title = b.Title,
            Author = b.Author,
            Isbn = b.ISBN,
            PublishedDate = b.PublishedDate.ToString("yyyy-MM-dd"),
            IsAvailable = b.IsAvailable,
            ActiveBorrowRecordId = activeBorrowRecordId
        };

        [HttpGet]
        public async Task<ActionResult<PagedResult<BookDto>>> Index(string? searchQuery, int page = 1)
        {
            var query = _context.Books.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                var q = searchQuery.Trim().ToLower();
                query = query.Where(b =>
                    (b.Title != null && b.Title.ToLower().Contains(q)) ||
                    (b.Author != null && b.Author.ToLower().Contains(q)) ||
                    (b.ISBN != null && b.ISBN.ToLower().Contains(q)));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

            var books = await query
                .OrderBy(b => b.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var bookIds = books.Select(b => b.BookId).ToList();
            var activeBorrows = await _context.BorrowRecords
                .Where(r => bookIds.Contains(r.BookId) && r.ReturnDate == null)
                .ToListAsync();

            var items = books.Select(b => ToDto(b, activeBorrows.FirstOrDefault(r => r.BookId == b.BookId)?.BorrowRecordId)).ToList();

            return Ok(new PagedResult<BookDto> { Items = items, CurrentPage = page, TotalPages = totalPages });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.BookId == id);
            if (book == null) return NotFound();

            var activeRecordId = await _context.BorrowRecords
                .Where(r => r.BookId == id && r.ReturnDate == null)
                .Select(r => (int?)r.BorrowRecordId)
                .FirstOrDefaultAsync();

            return Ok(ToDto(book, activeRecordId));
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Create(BookRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            if (!DateTime.TryParse(request.PublishedDate, out var publishedDate))
            {
                ModelState.AddModelError(nameof(request.PublishedDate), "Invalid date.");
                return ValidationProblem(ModelState);
            }

            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                ISBN = request.Isbn,
                PublishedDate = publishedDate,
                IsAvailable = true
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = book.BookId }, ToDto(book, null));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<BookDto>> Update(int id, BookRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            if (!DateTime.TryParse(request.PublishedDate, out var publishedDate))
            {
                ModelState.AddModelError(nameof(request.PublishedDate), "Invalid date.");
                return ValidationProblem(ModelState);
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            book.Title = request.Title;
            book.Author = request.Author;
            book.ISBN = request.Isbn;
            book.PublishedDate = publishedDate;

            await _context.SaveChangesAsync();

            var activeRecordId = await _context.BorrowRecords
                .Where(r => r.BookId == id && r.ReturnDate == null)
                .Select(r => (int?)r.BorrowRecordId)
                .FirstOrDefaultAsync();

            return Ok(ToDto(book, activeRecordId));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
