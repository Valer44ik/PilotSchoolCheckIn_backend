using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PilotSchoolCheckIn.Migrations
{
    /// <inheritdoc />
    public partial class AddednewcolumnAbbreviationforusertable : Migration
    {
        
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "User",
                type: "character varying(3)",
                maxLength: 3,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "User");
        }
    }
}
