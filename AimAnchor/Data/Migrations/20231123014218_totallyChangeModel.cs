using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AimAnchor.Data.Migrations
{
    /// <inheritdoc />
    public partial class totallyChangeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyFeedbacks_Goals_GoalId",
                table: "DailyFeedbacks");

            migrationBuilder.DropIndex(
                name: "IX_DailyFeedbacks_GoalId",
                table: "DailyFeedbacks");

            migrationBuilder.DropColumn(
                name: "GoalAchievementRating",
                table: "DailyFeedbacks");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "DailyFeedbacks");

            migrationBuilder.DropColumn(
                name: "Improvements",
                table: "DailyFeedbacks");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "DailyFeedbacks");

            migrationBuilder.DropColumn(
                name: "Reflection",
                table: "DailyFeedbacks");

            migrationBuilder.CreateTable(
                name: "FeedbackCartItems",
                columns: table => new
                {
                    FeedbackCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userSeassionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalAchievementRating = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Reflection = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Improvements = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackCartItems", x => x.FeedbackCartItemId);
                    table.ForeignKey(
                        name: "FK_FeedbackCartItems_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalAchievementRating = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Reflection = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Improvements = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false),
                    DailyFeedbackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_DailyFeedbacks_DailyFeedbackId",
                        column: x => x.DailyFeedbackId,
                        principalTable: "DailyFeedbacks",
                        principalColumn: "DailyFeedbackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackCartItems_GoalId",
                table: "FeedbackCartItems",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_DailyFeedbackId",
                table: "Feedbacks",
                column: "DailyFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_GoalId",
                table: "Feedbacks",
                column: "GoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackCartItems");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.AddColumn<int>(
                name: "GoalAchievementRating",
                table: "DailyFeedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "DailyFeedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Improvements",
                table: "DailyFeedbacks",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "DailyFeedbacks",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reflection",
                table: "DailyFeedbacks",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DailyFeedbacks_GoalId",
                table: "DailyFeedbacks",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyFeedbacks_Goals_GoalId",
                table: "DailyFeedbacks",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
