using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutApp.Migrations
{
    /// <inheritdoc />
    public partial class Matches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Matches",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MatchId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchType = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalGoals = table.Column<int>(type: "int", nullable: false),
                    VisitorGoals = table.Column<int>(type: "int", nullable: false),
                    Tactic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchStatics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    redCards = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchStatics_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_MatchId",
                table: "Players",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LocalId",
                table: "Matches",
                column: "LocalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamId",
                table: "Matches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VisitorId",
                table: "Matches",
                column: "VisitorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatics_MatchId",
                table: "MatchStatics",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Matches_MatchId",
                table: "Players",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Matches_MatchId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "MatchStatics");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Players_MatchId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Matches",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Players");
        }
    }
}
