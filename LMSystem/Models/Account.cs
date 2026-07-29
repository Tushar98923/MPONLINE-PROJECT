using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LMSystem.Models
{
    public enum AccountRole { Admin, Librarian, Teacher, Student }

    public class Account
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [BindNever]
        public string PasswordHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public AccountRole Role { get; set; }

        [BindNever]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
