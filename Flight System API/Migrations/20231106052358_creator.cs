using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_System_API.Migrations
{
    /// <inheritdoc />
    public partial class creator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Createtor",
                table: "DocumentTypes",
                newName: "Creator");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "DocumentTypes",
                newName: "Createtor");
        }
    }
}
