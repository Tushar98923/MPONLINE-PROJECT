using LMSystem.Models;

namespace LMSystem.ViewModels
{
    public class StudentListViewModel
    {
        public string? SearchTerm { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
