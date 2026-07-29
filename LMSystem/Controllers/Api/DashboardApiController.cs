using LMSystem.Dtos;
using LMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers.Api
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public DashboardApiController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardDto>> Get()
        {
            var borrowsPerBook = await _context.BorrowRecords
                .Include(r => r.Book)
                .GroupBy(r => r.Book!.Title)
                .Select(g => new BookBorrowCountDto { Title = g.Key!, Count = g.Count() })
                .OrderByDescending(c => c.Count)
                .ToListAsync();

            var dto = new DashboardDto
            {
                TotalBooks = await _context.Books.CountAsync(),
                AvailableBooks = await _context.Books.CountAsync(b => b.IsAvailable),
                TotalStudents = await _context.Students.CountAsync(),
                TotalLibrarians = await _context.Librarians.CountAsync(),
                TotalBorrowings = await _context.BorrowRecords.CountAsync(r => r.ReturnDate == null),
                TotalBorrowRecords = await _context.BorrowRecords.CountAsync(),
                ReturnedBorrows = await _context.BorrowRecords.CountAsync(r => r.ReturnDate != null),
                TotalPublications = await _context.Publications.CountAsync(),
                TotalNewspapers = await _context.Publications.CountAsync(p => p.Type == PublicationType.Newspaper),
                TotalMagazines = await _context.Publications.CountAsync(p => p.Type == PublicationType.Magazine),
                BorrowsPerBook = borrowsPerBook
            };

            return Ok(dto);
        }
    }
}
