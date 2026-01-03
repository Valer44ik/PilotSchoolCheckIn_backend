using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PilotSchoolCheckIn.Migrations
{
	public partial class ChangedentityrelationshipbetweenUsersPlanesandFlightReservationstables : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			// Drop the incorrect UNIQUE indexes
			migrationBuilder.DropIndex(
				name: "IX_FlightReservation_InstructorId",
				table: "FlightReservation");

			migrationBuilder.DropIndex(
				name: "IX_FlightReservation_PlaneId",
				table: "FlightReservation");

			// Recreate normal (non-unique) indexes for performance
			migrationBuilder.CreateIndex(
				name: "IX_FlightReservation_InstructorId",
				table: "FlightReservation",
				column: "InstructorId");

			migrationBuilder.CreateIndex(
				name: "IX_FlightReservation_PlaneId",
				table: "FlightReservation",
				column: "PlaneId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			// Restore the old UNIQUE indexes if rolling back
			migrationBuilder.DropIndex(
				name: "IX_FlightReservation_InstructorId",
				table: "FlightReservation");

			migrationBuilder.DropIndex(
				name: "IX_FlightReservation_PlaneId",
				table: "FlightReservation");

			migrationBuilder.CreateIndex(
				name: "IX_FlightReservation_InstructorId",
				table: "FlightReservation",
				column: "InstructorId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_FlightReservation_PlaneId",
				table: "FlightReservation",
				column: "PlaneId",
				unique: true);
		}
	}
}