using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bART_Solutions_TestTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Accounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Accounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
