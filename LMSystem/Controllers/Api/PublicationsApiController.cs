using LMSystem.Dtos;
using LMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers.Api
{
    [ApiController]
    [Route("api/publications")]
    public class PublicationsApiController : ControllerBase
    {
        private readonly LibraryContext _context;
        private const int PageSize = 5;

        public PublicationsApiController(LibraryContext context)
        {
            _context = context;
        }

        private static PublicationDto ToDto(Publication p) => new()
        {
            Id = p.Id,
            Title = p.Title,
            Publisher = p.Publisher,
            PublishedDate = p.PublishedDate.ToString("yyyy-MM-dd"),
            Type = p.Type.ToString(),
            IsAvailable = p.IsAvailable
        };

        [HttpGet]
        public async Task<ActionResult<PagedResult<PublicationDto>>> Index(string? type, string? searchString, int page = 1)
        {
            if (!Enum.TryParse<PublicationType>(type, true, out var pubType))
            {
                pubType = PublicationType.Newspaper;
            }

            var query = _context.Publications.AsNoTracking().Where(p => p.Type == pubType).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var term = searchString.Trim().ToLower();
                query = query.Where(p =>
                    (p.Title != null && p.Title.ToLower().Contains(term)) ||
                    (p.Publisher != null && p.Publisher.ToLower().Contains(term)));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

            var items = await query
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return Ok(new PagedResult<PublicationDto> { Items = items.Select(ToDto).ToList(), CurrentPage = page, TotalPages = totalPages });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PublicationDto>> Get(int id)
        {
            var publication = await _context.Publications.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (publication == null) return NotFound();
            return Ok(ToDto(publication));
        }

        [HttpPost]
        public async Task<ActionResult<PublicationDto>> Create(PublicationRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            if (!Enum.TryParse<PublicationType>(request.Type, true, out var pubType))
            {
                ModelState.AddModelError(nameof(request.Type), "Invalid publication type.");
                return ValidationProblem(ModelState);
            }
            if (!DateTime.TryParse(request.PublishedDate, out var publishedDate))
            {
                ModelState.AddModelError(nameof(request.PublishedDate), "Invalid date.");
                return ValidationProblem(ModelState);
            }

            var publication = new Publication
            {
                Title = request.Title,
                Publisher = request.Publisher,
                PublishedDate = publishedDate,
                Type = pubType,
                IsAvailable = true
            };

            _context.Publications.Add(publication);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = publication.Id }, ToDto(publication));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PublicationDto>> Update(int id, PublicationRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            if (!Enum.TryParse<PublicationType>(request.Type, true, out var pubType))
            {
                ModelState.AddModelError(nameof(request.Type), "Invalid publication type.");
                return ValidationProblem(ModelState);
            }
            if (!DateTime.TryParse(request.PublishedDate, out var publishedDate))
            {
                ModelState.AddModelError(nameof(request.PublishedDate), "Invalid date.");
                return ValidationProblem(ModelState);
            }

            var publication = await _context.Publications.FindAsync(id);
            if (publication == null) return NotFound();

            publication.Title = request.Title;
            publication.Publisher = request.Publisher;
            publication.PublishedDate = publishedDate;
            publication.Type = pubType;
            publication.IsAvailable = request.IsAvailable;

            await _context.SaveChangesAsync();
            return Ok(ToDto(publication));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var publication = await _context.Publications.FindAsync(id);
            if (publication == null) return NotFound();

            _context.Publications.Remove(publication);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
