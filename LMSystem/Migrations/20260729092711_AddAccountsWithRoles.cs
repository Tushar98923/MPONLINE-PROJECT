using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountsWithRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginUsers");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), "admin@lmsystem.local", "System Administrator", "100000.cAaHypSNyiDLLSWROAi+nQ==.yXOQZRWghbSbFRKUMroDt2ZSM5rofXkqyluzxNBvi8A=", 0, "admin" },
                    { 2, new DateTime(2026, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), "meera.joshi@lmsystem.local", "Meera Joshi", "100000.EPT7EsDZ9dsgg4QZ8+ZHYQ==.a5OMPHUuu7quNUkK7dPBcAXLby4gDJp+sifquUTGkAc=", 1, "mycodingproject" },
                    { 3, new DateTime(2026, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), "aditi.verma@lmsystem.local", "Aditi Verma", "100000.a8oLge7LPfmpHJMjZzw99g==.xhoqrAmheO2tgnWEBZaymw7P0qVyjY+k/NDhGgsI1fo=", 3, "my" }
                });

            migrationBuilder.UpdateData(
                table: "BorrowRecords",
                keyColumn: "BorrowRecordId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2026, 7, 27, 9, 27, 11, 384, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "BorrowRecords",
                keyColumn: "BorrowRecordId",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2026, 7, 19, 9, 27, 11, 384, DateTimeKind.Utc).AddTicks(2470), new DateTime(2026, 7, 26, 9, 27, 11, 384, DateTimeKind.Utc).AddTicks(2471) });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username",
                table: "Accounts",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.CreateTable(
                name: "LoginUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BorrowRecords",
                keyColumn: "BorrowRecordId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2026, 7, 27, 4, 42, 4, 157, DateTimeKind.Utc).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "BorrowRecords",
                keyColumn: "BorrowRecordId",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2026, 7, 19, 4, 42, 4, 157, DateTimeKind.Utc).AddTicks(3313), new DateTime(2026, 7, 26, 4, 42, 4, 157, DateTimeKind.Utc).AddTicks(3313) });

            migrationBuilder.InsertData(
                table: "LoginUsers",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "12345", "admin" },
                    { 2, "myc546", "mycodingproject" },
                    { 3, "myc", "my" }
                });
        }
    }
}
