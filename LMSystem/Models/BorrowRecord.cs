using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LMSystem.Models
{
    public class BorrowRecord
    {
        [Key]
        public int BorrowRecordId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter the borrower name.")]
        [StringLength(100)]
        public string? BorrowerName { get; set; }

        [Required(ErrorMessage = "Please enter the borrower email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? BorrowerEmail { get; set; }

        [Required(ErrorMessage = "Please enter the borrower phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string? Phone { get; set; }

        [BindNever]
        [DataType(DataType.DateTime)]
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime? ReturnDate { get; set; }

        [BindNever]
        public Book? Book { get; set; }
    }
}
