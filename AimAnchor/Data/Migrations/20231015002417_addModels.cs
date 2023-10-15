using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AimAnchor.Data.Migrations
{
    /// <inheritdoc />
    public partial class addModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoalSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReflectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayRating = table.Column<int>(type: "int", nullable: false),
                    HighlightOfDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChallengeOfTheday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonOfTheDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImprovmentForTomorrow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyFeedbacks_GoalSets_GoalSetId",
                        column: x => x.GoalSetId,
                        principalTable: "GoalSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoalSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_Goals_GoalSets_GoalSetId",
                        column: x => x.GoalSetId,
                        principalTable: "GoalSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyFeedbacks_GoalSetId",
                table: "DailyFeedbacks",
                column: "GoalSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalSetId",
                table: "Goals",
                column: "GoalSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyFeedbacks");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "GoalSets");
        }
    }
}
