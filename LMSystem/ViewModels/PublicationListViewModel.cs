using LMSystem.Models;

namespace LMSystem.ViewModels
{
    public class PublicationListViewModel
    {
        public List<Publication> Publications { get; set; } = new List<Publication>();
        public PublicationType Type { get; set; }
        public string? SearchString { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}
