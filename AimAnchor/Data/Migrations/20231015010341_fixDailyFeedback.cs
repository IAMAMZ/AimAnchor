using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AimAnchor.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixDailyFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyFeedbacks_GoalSets_GoalSetId",
                table: "DailyFeedbacks");

            migrationBuilder.RenameColumn(
                name: "GoalSetId",
                table: "DailyFeedbacks",
                newName: "GoalsetId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyFeedbacks_GoalSetId",
                table: "DailyFeedbacks",
                newName: "IX_DailyFeedbacks_GoalsetId");

            migrationBuilder.AddColumn<int>(
                name: "DailyFeedbackId",
                table: "GoalSets",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImprovmentForTomorrow",
                table: "DailyFeedbacks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GoalsetId",
                table: "DailyFeedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "GoalsetId",
                table: "DailyFeedbacks",
                newName: "GoalSetId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyFeedbacks_GoalsetId",
                table: "DailyFeedbacks",
                newName: "IX_DailyFeedbacks_GoalSetId");

            migrationBuilder.AlterColumn<string>(
                name: "ImprovmentForTomorrow",
                table: "DailyFeedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GoalSetId",
                table: "DailyFeedbacks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyFeedbacks_GoalSets_GoalSetId",
                table: "DailyFeedbacks",
                column: "GoalSetId",
                principalTable: "GoalSets",
                principalColumn: "Id");
        }
    }
}
