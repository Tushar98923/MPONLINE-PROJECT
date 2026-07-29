using Microsoft.AspNetCore.Mvc;

namespace LMSystem.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(string contactName, string contactEmail, string contactMessage)
        {
            if (string.IsNullOrWhiteSpace(contactName) || string.IsNullOrWhiteSpace(contactEmail) || string.IsNullOrWhiteSpace(contactMessage))
            {
                TempData["ErrorMessage"] = "Please fill in all fields.";
                return RedirectToAction(nameof(Contact));
            }

            TempData["SuccessMessage"] = "Thanks for reaching out - our library team will get back to you soon.";
            return RedirectToAction(nameof(Contact));
        }
    }
}
