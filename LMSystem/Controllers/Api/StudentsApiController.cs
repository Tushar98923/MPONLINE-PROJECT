using LMSystem.Dtos;
using LMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers.Api
{
    [ApiController]
    [Route("api/students")]
    public class StudentsApiController : ControllerBase
    {
        private readonly LibraryContext _context;
        private const int PageSize = 5;

        public StudentsApiController(LibraryContext context)
        {
            _context = context;
        }

        private static StudentDto ToDto(Student s) => new()
        {
            StudentId = s.StudentId,
            StudentName = s.StudentName,
            Email = s.Email,
            Phone = s.Phone
        };

        [HttpGet]
        public async Task<ActionResult<PagedResult<StudentDto>>> Index(string? searchTerm, int page = 1)
        {
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
            int totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

            var students = await query
                .OrderBy(s => s.StudentId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return Ok(new PagedResult<StudentDto> { Items = students.Select(ToDto).ToList(), CurrentPage = page, TotalPages = totalPages });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.StudentId == id);
            if (student == null) return NotFound();
            return Ok(ToDto(student));
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create(StudentRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var student = new Student { StudentName = request.StudentName, Email = request.Email, Phone = request.Phone };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = student.StudentId }, ToDto(student));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StudentDto>> Update(int id, StudentRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.StudentName = request.StudentName;
            student.Email = request.Email;
            student.Phone = request.Phone;

            await _context.SaveChangesAsync();
            return Ok(ToDto(student));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
