using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AimAnchor.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDailyFeedback : Migration
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
                newName: "GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyFeedbacks_GoalSetId",
                table: "DailyFeedbacks",
                newName: "IX_DailyFeedbacks_GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyFeedbacks_Goals_GoalId",
                table: "DailyFeedbacks",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyFeedbacks_Goals_GoalId",
                table: "DailyFeedbacks");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "DailyFeedbacks",
                newName: "GoalSetId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyFeedbacks_GoalId",
                table: "DailyFeedbacks",
                newName: "IX_DailyFeedbacks_GoalSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyFeedbacks_GoalSets_GoalSetId",
                table: "DailyFeedbacks",
                column: "GoalSetId",
                principalTable: "GoalSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
