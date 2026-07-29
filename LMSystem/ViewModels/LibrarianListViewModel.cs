using LMSystem.Models;

namespace LMSystem.ViewModels
{
    public class LibrarianListViewModel
    {
        public List<Librarian> Librarians { get; set; } = new List<Librarian>();
        public string? SearchTerm { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
    }
}
