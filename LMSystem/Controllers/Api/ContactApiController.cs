using LMSystem.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LMSystem.Controllers.Api
{
    [ApiController]
    [Route("api/contact")]
    public class ContactApiController : ControllerBase
    {
        [HttpPost]
        public IActionResult Submit(ContactRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            return Ok(new { message = "Thanks for reaching out - our library team will get back to you soon." });
        }
    }
}
