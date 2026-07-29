namespace LMSystem.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int TotalBooks { get; set; }
        public int TotalLibrarians { get; set; }
        public int TotalBorrowings { get; set; }
        public int TotalPublications { get; set; }
        public int TotalNewspapers { get; set; }
        public int TotalMagazines { get; set; }
        public int AvailableBooks { get; set; }
        public int ReturnedBorrows { get; set; }
        public int TotalBorrowRecords { get; set; }
        public List<BookBorrowCount> BorrowsPerBook { get; set; } = new List<BookBorrowCount>();
    }

    public class BookBorrowCount
    {
        public string Title { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
