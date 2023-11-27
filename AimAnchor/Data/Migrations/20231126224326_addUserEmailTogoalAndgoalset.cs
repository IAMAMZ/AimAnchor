using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AimAnchor.Data.Migrations
{
    /// <inheritdoc />
    public partial class addUserEmailTogoalAndgoalset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "GoalSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "GoalSets");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Goals");
        }
    }
}
