using LMSystem.Models;

namespace LMSystem.ViewModels
{
    public class AccountListViewModel
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        public string? SearchTerm { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
    }
}
