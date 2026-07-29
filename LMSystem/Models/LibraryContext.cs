using Microsoft.EntityFrameworkCore;

namespace LMSystem.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<BorrowRecord> BorrowRecords => Set<BorrowRecord>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Librarian> Librarians => Set<Librarian>();
        public DbSet<Publication> Publications => Set<Publication>();
        public DbSet<Account> Accounts => Set<Account>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publication>()
                .Property(p => p.Type)
                .HasConversion<int>();

            modelBuilder.Entity<Account>()
                .Property(a => a.Role)
                .HasConversion<int>();

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Username)
                .IsUnique();

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "The Pragmatic Programmer", Author = "Andrew Hunt and David Thomas", ISBN = "978-0201616224", PublishedDate = new DateTime(2021, 10, 30), IsAvailable = true },
                new Book { BookId = 2, Title = "Design Pattern using C#", Author = "Robert C. Martin", ISBN = "978-0132350884", PublishedDate = new DateTime(2023, 8, 1), IsAvailable = false },
                new Book { BookId = 3, Title = "Mastering ASP.NET Core", Author = "Pranaya Kumar Rout", ISBN = "978-0451616235", PublishedDate = new DateTime(2022, 11, 22), IsAvailable = true },
                new Book { BookId = 4, Title = "SQL Server with DBA", Author = "Rakesh Kumar", ISBN = "978-4562350123", PublishedDate = new DateTime(2020, 8, 15), IsAvailable = true },
                new Book { BookId = 5, Title = "Clean Code", Author = "Robert C. Martin", ISBN = "978-0132350702", PublishedDate = new DateTime(2008, 8, 1), IsAvailable = true },
                new Book { BookId = 6, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", ISBN = "978-0262033848", PublishedDate = new DateTime(2009, 7, 31), IsAvailable = true },
                new Book { BookId = 7, Title = "You Don't Know JS Yet", Author = "Kyle Simpson", ISBN = "978-1091210095", PublishedDate = new DateTime(2020, 1, 27), IsAvailable = true },
                new Book { BookId = 8, Title = "Refactoring", Author = "Martin Fowler", ISBN = "978-0134757599", PublishedDate = new DateTime(2018, 11, 20), IsAvailable = true }
            );

            modelBuilder.Entity<BorrowRecord>().HasData(
                new BorrowRecord { BorrowRecordId = 1, BookId = 2, BorrowerName = "Priya Sharma", BorrowerEmail = "priya.sharma@example.com", Phone = "+91 98765 43210", BorrowDate = DateTime.UtcNow.AddDays(-2), ReturnDate = null },
                new BorrowRecord { BorrowRecordId = 2, BookId = 5, BorrowerName = "Arjun Mehta", BorrowerEmail = "arjun.mehta@example.com", Phone = "+91 91234 56789", BorrowDate = DateTime.UtcNow.AddDays(-10), ReturnDate = DateTime.UtcNow.AddDays(-3) }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "Aditi Verma", Email = "aditi.verma@example.com", Phone = "+91 90000 11111" },
                new Student { StudentId = 2, StudentName = "Rohan Gupta", Email = "rohan.gupta@example.com", Phone = "+91 90000 22222" },
                new Student { StudentId = 3, StudentName = "Sneha Kapoor", Email = "sneha.kapoor@example.com", Phone = "+91 90000 33333" },
                new Student { StudentId = 4, StudentName = "Karan Malhotra", Email = "karan.malhotra@example.com", Phone = "+91 90000 44444" },
                new Student { StudentId = 5, StudentName = "Isha Nair", Email = "isha.nair@example.com", Phone = "+91 90000 55555" },
                new Student { StudentId = 6, StudentName = "Vikram Singh", Email = "vikram.singh@example.com", Phone = "+91 90000 66666" }
            );

            modelBuilder.Entity<Librarian>().HasData(
                new Librarian { LibrarianId = 1, Name = "Meera Joshi", Age = 34, Phone = "+91 90000 77777" },
                new Librarian { LibrarianId = 2, Name = "Sanjay Rao", Age = 41, Phone = "+91 90000 88888" },
                new Librarian { LibrarianId = 3, Name = "Neha Bhatt", Age = 29, Phone = "+91 90000 99999" },
                new Librarian { LibrarianId = 4, Name = "Arvind Menon", Age = 38, Phone = "+91 90000 12121" },
                new Librarian { LibrarianId = 5, Name = "Pooja Iyer", Age = 45, Phone = "+91 90000 13131" },
                new Librarian { LibrarianId = 6, Name = "Farhan Sheikh", Age = 31, Phone = "+91 90000 14141" }
            );

            modelBuilder.Entity<Publication>().HasData(
                new Publication { Id = 1, Title = "The Daily Times", Publisher = "Global Media Group", PublishedDate = new DateTime(2026, 7, 22), Type = PublicationType.Newspaper, IsAvailable = true },
                new Publication { Id = 2, Title = "Financial Chronicle", Publisher = "WallSt Press", PublishedDate = new DateTime(2026, 7, 21), Type = PublicationType.Newspaper, IsAvailable = true },
                new Publication { Id = 3, Title = "Tech Weekly News", Publisher = "Silicon Valley Pubs", PublishedDate = new DateTime(2026, 7, 20), Type = PublicationType.Newspaper, IsAvailable = true },
                new Publication { Id = 4, Title = "Metro Morning Post", Publisher = "City Press House", PublishedDate = new DateTime(2026, 7, 22), Type = PublicationType.Newspaper, IsAvailable = true },
                new Publication { Id = 5, Title = "Saturday Sports Herald", Publisher = "Global Media Group", PublishedDate = new DateTime(2026, 7, 18), Type = PublicationType.Newspaper, IsAvailable = false },
                new Publication { Id = 6, Title = "National Geographic Vol 45", Publisher = "NatGeo Society", PublishedDate = new DateTime(2026, 7, 1), Type = PublicationType.Magazine, IsAvailable = true },
                new Publication { Id = 7, Title = "Vogue Fashion Summer", Publisher = "Conde Nast", PublishedDate = new DateTime(2026, 6, 15), Type = PublicationType.Magazine, IsAvailable = true },
                new Publication { Id = 8, Title = "Forbes Business 30 Under 30", Publisher = "Forbes Media", PublishedDate = new DateTime(2026, 7, 10), Type = PublicationType.Magazine, IsAvailable = false },
                new Publication { Id = 9, Title = "PC Gamer Ultimate", Publisher = "Future US", PublishedDate = new DateTime(2026, 7, 5), Type = PublicationType.Magazine, IsAvailable = true },
                new Publication { Id = 10, Title = "Scientific American", Publisher = "Springer Nature", PublishedDate = new DateTime(2026, 6, 28), Type = PublicationType.Magazine, IsAvailable = true }
            );

            var seedCreatedAt = new DateTime(2026, 7, 29, 0, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Username = "admin",
                    // Password: 12345
                    PasswordHash = "100000.cAaHypSNyiDLLSWROAi+nQ==.yXOQZRWghbSbFRKUMroDt2ZSM5rofXkqyluzxNBvi8A=",
                    FullName = "System Administrator",
                    Email = "admin@lmsystem.local",
                    Role = AccountRole.Admin,
                    CreatedAt = seedCreatedAt
                },
                new Account
                {
                    Id = 2,
                    Username = "mycodingproject",
                    // Password: myc546
                    PasswordHash = "100000.EPT7EsDZ9dsgg4QZ8+ZHYQ==.a5OMPHUuu7quNUkK7dPBcAXLby4gDJp+sifquUTGkAc=",
                    FullName = "Meera Joshi",
                    Email = "meera.joshi@lmsystem.local",
                    Role = AccountRole.Librarian,
                    CreatedAt = seedCreatedAt
                },
                new Account
                {
                    Id = 3,
                    Username = "my",
                    // Password: myc
                    PasswordHash = "100000.a8oLge7LPfmpHJMjZzw99g==.xhoqrAmheO2tgnWEBZaymw7P0qVyjY+k/NDhGgsI1fo=",
                    FullName = "Aditi Verma",
                    Email = "aditi.verma@lmsystem.local",
                    Role = AccountRole.Student,
                    CreatedAt = seedCreatedAt
                }
            );
        }
    }
}
