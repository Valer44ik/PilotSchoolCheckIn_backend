using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.DatabaseTables;

[Table("FlightReservation")]
public sealed class FlightReservation
{
	[Column("id")]
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }
	
	public long ClientId { get; set; }
	
	public long InstructorId { get; set; }
	
	public long PlaneId { get; set; }
	
	public required DateTime StartsAt { get; set; }
	
	public required DateTime EndsAt { get; set; }
	
	public required FlightStatus Status { get; set; }
	
	[MaxLength(500)]
	public string? Note { get; set; }
	
	public required DateTime AcceptedAt { get; set; }

	public required DateTime CreatedAt { get; set; }
	
	public required DateTime UpdatedAt { get; set; }
	
	public required User Client { get; set; }
	
	public required User Instructor { get; set; }
	
	public required Plane Plane { get; set; }

	[SetsRequiredMembers]
	public FlightReservation(long id, long clientId, long instructorId, long planeId, DateTime startsAt, DateTime endsAt, string note,
		DateTime createdAt, DateTime updatedAt, FlightStatus status)
	{
		Id = id;
		ClientId = clientId;
		InstructorId = instructorId;
		PlaneId = planeId;
		StartsAt = startsAt;
		EndsAt = endsAt;
		Note = note;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		Status = status;
	}
}