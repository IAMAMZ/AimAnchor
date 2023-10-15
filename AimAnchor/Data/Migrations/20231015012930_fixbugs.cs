using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AimAnchor.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixbugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyFeedbacks_GoalSets_GoalsetId",
                table: "DailyFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalSets_DailyFeedbacks_DailyFeedbackId",
                table: "GoalSets");

            migrationBuilder.DropIndex(
                name: "IX_GoalSets_DailyFeedbackId",
                table: "GoalSets");

            migrationBuilder.DropColumn(
                name: "DailyFeedbackId",
                table: "GoalSets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GoalSets");

            migrationBuilder.DropColumn(
                name: "ChallengeOfTheday",
                table: "DailyFeedbacks");

            migrationBuilder.DropColumn(
                name: "HighlightOfDay",
                table: "DailyFeedbacks");

            migrationBuilder.DropColumn(
                name: "ImprovmentForTomorrow",
                table: "DailyFeedbacks");

            migrationBuilder.DropColumn(
                name: "LessonOfTheDay",
                table: "DailyFeedbacks");

            migrationBuilder.RenameColumn(
                name: "GoalsetId",
                table: "DailyFeedbacks",
                newName: "GoalSetId");

            migrationBuilder.RenameColumn(
                name: "ReflectionDate",
                table: "DailyFeedbacks",
                newName: "FeedbackDate");

            migrationBuilder.RenameColumn(
                name: "DayRating",
                table: "DailyFeedbacks",
                newName: "GoalAchievementRating");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DailyFeedbacks",
                newName: "DailyFeedbackId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyFeedbacks_GoalsetId",
                table: "DailyFeedbacks",
                newName: "IX_DailyFeedbacks_GoalSetId");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "GoalSets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DailyFeedbacks_GoalSets_GoalSetId",
                table: "DailyFeedbacks",
                column: "GoalSetId",
                principalTable: "GoalSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyFeedbacks_GoalSets_GoalSetId",
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

            migrationBuilder.RenameColumn(
                name: "GoalSetId",
                table: "DailyFeedbacks",
                newName: "GoalsetId");

            migrationBuilder.RenameColumn(
                name: "GoalAchievementRating",
                table: "DailyFeedbacks",
                newName: "DayRating");

            migrationBuilder.RenameColumn(
                name: "FeedbackDate",
                table: "DailyFeedbacks",
                newName: "ReflectionDate");

            migrationBuilder.RenameColumn(
                name: "DailyFeedbackId",
                table: "DailyFeedbacks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DailyFeedbacks_GoalSetId",
                table: "DailyFeedbacks",
                newName: "IX_DailyFeedbacks_GoalsetId");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "GoalSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DailyFeedbackId",
                table: "GoalSets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GoalSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChallengeOfTheday",
                table: "DailyFeedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HighlightOfDay",
                table: "DailyFeedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImprovmentForTomorrow",
                table: "DailyFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonOfTheDay",
                table: "DailyFeedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GoalSets_DailyFeedbackId",
                table: "GoalSets",
                column: "DailyFeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyFeedbacks_GoalSets_GoalsetId",
                table: "DailyFeedbacks",
                column: "GoalsetId",
                principalTable: "GoalSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalSets_DailyFeedbacks_DailyFeedbackId",
                table: "GoalSets",
                column: "DailyFeedbackId",
                principalTable: "DailyFeedbacks",
                principalColumn: "Id");
        }
    }
}
