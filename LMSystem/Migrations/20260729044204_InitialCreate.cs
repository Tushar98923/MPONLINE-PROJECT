using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Librarians",
                columns: table => new
                {
                    LibrarianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarians", x => x.LibrarianId);
                });

            migrationBuilder.CreateTable(
                name: "LoginUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "BorrowRecords",
                columns: table => new
                {
                    BorrowRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BorrowerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRecords", x => x.BorrowRecordId);
                    table.ForeignKey(
                        name: "FK_BorrowRecords_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "ISBN", "IsAvailable", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Andrew Hunt and David Thomas", "978-0201616224", true, new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Pragmatic Programmer" },
                    { 2, "Robert C. Martin", "978-0132350884", false, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design Pattern using C#" },
                    { 3, "Pranaya Kumar Rout", "978-0451616235", true, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mastering ASP.NET Core" },
                    { 4, "Rakesh Kumar", "978-4562350123", true, new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL Server with DBA" },
                    { 5, "Robert C. Martin", "978-0132350702", true, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code" },
                    { 6, "Thomas H. Cormen", "978-0262033848", true, new DateTime(2009, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to Algorithms" },
                    { 7, "Kyle Simpson", "978-1091210095", true, new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "You Don't Know JS Yet" },
                    { 8, "Martin Fowler", "978-0134757599", true, new DateTime(2018, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring" }
                });

            migrationBuilder.InsertData(
                table: "Librarians",
                columns: new[] { "LibrarianId", "Age", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 34, "Meera Joshi", "+91 90000 77777" },
                    { 2, 41, "Sanjay Rao", "+91 90000 88888" },
                    { 3, 29, "Neha Bhatt", "+91 90000 99999" },
                    { 4, 38, "Arvind Menon", "+91 90000 12121" },
                    { 5, 45, "Pooja Iyer", "+91 90000 13131" },
                    { 6, 31, "Farhan Sheikh", "+91 90000 14141" }
                });

            migrationBuilder.InsertData(
                table: "LoginUsers",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "12345", "admin" },
                    { 2, "myc546", "mycodingproject" },
                    { 3, "myc", "my" }
                });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "IsAvailable", "PublishedDate", "Publisher", "Title", "Type" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Media Group", "The Daily Times", 0 },
                    { 2, true, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "WallSt Press", "Financial Chronicle", 0 },
                    { 3, true, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silicon Valley Pubs", "Tech Weekly News", 0 },
                    { 4, true, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Press House", "Metro Morning Post", 0 },
                    { 5, false, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Media Group", "Saturday Sports Herald", 0 },
                    { 6, true, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NatGeo Society", "National Geographic Vol 45", 1 },
                    { 7, true, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conde Nast", "Vogue Fashion Summer", 1 },
                    { 8, false, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forbes Media", "Forbes Business 30 Under 30", 1 },
                    { 9, true, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future US", "PC Gamer Ultimate", 1 },
                    { 10, true, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Springer Nature", "Scientific American", 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Email", "Phone", "StudentName" },
                values: new object[,]
                {
                    { 1, "aditi.verma@example.com", "+91 90000 11111", "Aditi Verma" },
                    { 2, "rohan.gupta@example.com", "+91 90000 22222", "Rohan Gupta" },
                    { 3, "sneha.kapoor@example.com", "+91 90000 33333", "Sneha Kapoor" },
                    { 4, "karan.malhotra@example.com", "+91 90000 44444", "Karan Malhotra" },
                    { 5, "isha.nair@example.com", "+91 90000 55555", "Isha Nair" },
                    { 6, "vikram.singh@example.com", "+91 90000 66666", "Vikram Singh" }
                });

            migrationBuilder.InsertData(
                table: "BorrowRecords",
                columns: new[] { "BorrowRecordId", "BookId", "BorrowDate", "BorrowerEmail", "BorrowerName", "Phone", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2026, 7, 27, 4, 42, 4, 157, DateTimeKind.Utc).AddTicks(3305), "priya.sharma@example.com", "Priya Sharma", "+91 98765 43210", null },
                    { 2, 5, new DateTime(2026, 7, 19, 4, 42, 4, 157, DateTimeKind.Utc).AddTicks(3313), "arjun.mehta@example.com", "Arjun Mehta", "+91 91234 56789", new DateTime(2026, 7, 26, 4, 42, 4, 157, DateTimeKind.Utc).AddTicks(3313) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecords_BookId",
                table: "BorrowRecords",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowRecords");

            migrationBuilder.DropTable(
                name: "Librarians");

            migrationBuilder.DropTable(
                name: "LoginUsers");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
