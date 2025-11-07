using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PilotSchoolCheckIn.Migrations
{
    /// <inheritdoc />
    public partial class ChangedusercolumnAgetoBirthYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthYear",
                table: "User",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "User");

            migrationBuilder.AddColumn<long>(
                name: "Age",
                table: "User",
                type: "bigint",
                nullable: true);
        }
    }
}
