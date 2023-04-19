using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutApp.Migrations
{
    /// <inheritdoc />
    public partial class Goals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Golas",
                table: "Players",
                newName: "Goals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Goals",
                table: "Players",
                newName: "Golas");
        }
    }
}
