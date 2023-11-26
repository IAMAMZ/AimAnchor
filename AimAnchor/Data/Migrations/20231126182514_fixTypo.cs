using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AimAnchor.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userSeassionId",
                table: "FeedbackCartItems",
                newName: "userSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userSessionId",
                table: "FeedbackCartItems",
                newName: "userSeassionId");
        }
    }
}
