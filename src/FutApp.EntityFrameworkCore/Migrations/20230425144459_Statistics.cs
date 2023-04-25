using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutApp.Migrations
{
    /// <inheritdoc />
    public partial class Statistics : Migration
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

            migrationBuilder.DropColumn(
                name: "Asists",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "RedCards",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "YellowCards",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Asists",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RedCards",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "YellowCards",
                table: "Players");

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

            migrationBuilder.AddColumn<Guid>(
                name: "StatisticID",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StatisticID",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Asists = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StatisticID",
                table: "Teams",
                column: "StatisticID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_StatisticID",
                table: "Players",
                column: "StatisticID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Statistics_StatisticID",
                table: "Players",
                column: "StatisticID",
                principalTable: "Statistics",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Statistics_StatisticID",
                table: "Teams",
                column: "StatisticID",
                principalTable: "Statistics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Statistics_StatisticID",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Players_PlayerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Teams_TeamId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Statistics_StatisticID",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Teams_StatisticID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Players_StatisticID",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StatisticID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StatisticID",
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

            migrationBuilder.AddColumn<int>(
                name: "Asists",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedCards",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YellowCards",
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

            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedCards",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YellowCards",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
