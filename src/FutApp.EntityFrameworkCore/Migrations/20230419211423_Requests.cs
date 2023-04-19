using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutApp.Migrations
{
    /// <inheritdoc />
    public partial class Requests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Players_PlayerId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Teams_TeamId",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameIndex(
                name: "IX_Request_TeamId",
                table: "Requests",
                newName: "IX_Requests_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_PlayerId",
                table: "Requests",
                newName: "IX_Requests_PlayerId");

            migrationBuilder.AddColumn<int>(
                name: "Asists",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Asists",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Players_PlayerId",
                table: "Requests",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Teams_TeamId",
                table: "Requests",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Players_PlayerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Teams_TeamId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Asists",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Asists",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_TeamId",
                table: "Request",
                newName: "IX_Request_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_PlayerId",
                table: "Request",
                newName: "IX_Request_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Players_PlayerId",
                table: "Request",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Teams_TeamId",
                table: "Request",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
