using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LMSystem.Models
{
    public enum PublicationType { Newspaper, Magazine }

    public class Publication
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Publisher is required.")]
        [StringLength(50)]
        public string? Publisher { get; set; }

        [Required(ErrorMessage = "Published date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        [Required]
        public PublicationType Type { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
