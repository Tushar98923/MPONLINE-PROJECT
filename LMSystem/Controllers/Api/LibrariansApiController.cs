using LMSystem.Dtos;
using LMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers.Api
{
    [ApiController]
    [Route("api/librarians")]
    public class LibrariansApiController : ControllerBase
    {
        private readonly LibraryContext _context;
        private const int PageSize = 5;

        public LibrariansApiController(LibraryContext context)
        {
            _context = context;
        }

        private static LibrarianDto ToDto(Librarian l) => new()
        {
            LibrarianId = l.LibrarianId,
            Name = l.Name,
            Age = l.Age,
            Phone = l.Phone
        };

        [HttpGet]
        public async Task<ActionResult<PagedResult<LibrarianDto>>> Index(string? searchTerm, int page = 1)
        {
            var query = _context.Librarians.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();
                query = query.Where(l => l.Name != null && l.Name.ToLower().Contains(term));
            }

            int totalRecords = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

            var librarians = await query
                .OrderBy(l => l.LibrarianId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return Ok(new PagedResult<LibrarianDto> { Items = librarians.Select(ToDto).ToList(), CurrentPage = page, TotalPages = totalPages });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibrarianDto>> Get(int id)
        {
            var librarian = await _context.Librarians.AsNoTracking().FirstOrDefaultAsync(l => l.LibrarianId == id);
            if (librarian == null) return NotFound();
            return Ok(ToDto(librarian));
        }

        [HttpPost]
        public async Task<ActionResult<LibrarianDto>> Create(LibrarianRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var librarian = new Librarian { Name = request.Name, Age = request.Age, Phone = request.Phone };
            _context.Librarians.Add(librarian);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = librarian.LibrarianId }, ToDto(librarian));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<LibrarianDto>> Update(int id, LibrarianRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var librarian = await _context.Librarians.FindAsync(id);
            if (librarian == null) return NotFound();

            librarian.Name = request.Name;
            librarian.Age = request.Age;
            librarian.Phone = request.Phone;

            await _context.SaveChangesAsync();
            return Ok(ToDto(librarian));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);
            if (librarian == null) return NotFound();

            _context.Librarians.Remove(librarian);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
