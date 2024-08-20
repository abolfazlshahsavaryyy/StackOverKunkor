using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Konkor.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminDataToSimpleOneForTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "RamsShab" },
                values: new object[] { "a", "a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "RamsShab" },
                values: new object[] { "Abolfazl", "ASP.NET core" });
        }
    }
}
