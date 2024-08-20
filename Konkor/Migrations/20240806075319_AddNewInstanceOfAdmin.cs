using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Konkor.Migrations
{
    /// <inheritdoc />
    public partial class AddNewInstanceOfAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Name", "RamsShab" },
                values: new object[] { 1, "Abolfazl", "ASP.NET core" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
