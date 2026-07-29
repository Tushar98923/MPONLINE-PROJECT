using System.ComponentModel.DataAnnotations;

namespace LMSystem.Dtos
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

    public class BookDto
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public string PublishedDate { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public int? ActiveBorrowRecordId { get; set; }
    }

    public class BookRequest
    {
        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "The Author field is required.")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters.")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "The ISBN field is required.")]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "ISBN must be in the format XXX-XXXXXXXXXX.")]
        public string? Isbn { get; set; }

        [Required(ErrorMessage = "The Published Date field is required.")]
        public string? PublishedDate { get; set; }
    }

    public class BorrowRequest
    {
        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Your name is required.")]
        [StringLength(100)]
        public string? BorrowerName { get; set; }

        [Required(ErrorMessage = "Your email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? BorrowerEmail { get; set; }

        [Required(ErrorMessage = "Your phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }
    }

    public class StudentDto
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class StudentRequest
    {
        [Required(ErrorMessage = "Student name is required.")]
        [StringLength(100)]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }
    }

    public class LibrarianDto
    {
        public int LibrarianId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Phone { get; set; }
    }

    public class LibrarianRequest
    {
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

    public class PublicationDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Publisher { get; set; }
        public string PublishedDate { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }

    public class PublicationRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Publisher is required.")]
        [StringLength(50)]
        public string? Publisher { get; set; }

        [Required(ErrorMessage = "Published date is required.")]
        public string? PublishedDate { get; set; }

        [Required]
        public string? Type { get; set; }

        public bool IsAvailable { get; set; } = true;
    }

    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }

    public class ContactRequest
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter a message.")]
        public string? Message { get; set; }
    }

    public class DashboardDto
    {
        public int TotalBooks { get; set; }
        public int AvailableBooks { get; set; }
        public int TotalStudents { get; set; }
        public int TotalLibrarians { get; set; }
        public int TotalBorrowings { get; set; }
        public int TotalBorrowRecords { get; set; }
        public int ReturnedBorrows { get; set; }
        public int TotalPublications { get; set; }
        public int TotalNewspapers { get; set; }
        public int TotalMagazines { get; set; }
        public List<BookBorrowCountDto> BorrowsPerBook { get; set; } = new();
    }

    public class BookBorrowCountDto
    {
        public string Title { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
