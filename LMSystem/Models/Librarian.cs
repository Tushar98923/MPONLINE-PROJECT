using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LMSystem.Models
{
    public class Librarian
    {
        [BindNever]
        public int LibrarianId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 100, ErrorMessage = "Enter a valid age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }
    }
}
