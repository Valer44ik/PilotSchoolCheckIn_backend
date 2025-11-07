using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.DatabaseTables;

[Table("FlightReservation")]
public sealed class FlightReservation
{
	[Column("id")]
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }
	
	public long? ClientId { get; set; }
	
	public long? InstructorId { get; set; }
	
	public long? PlaneId { get; set; }
	
	public required DateTime StartsAt { get; set; }
	
	public required DateTime EndsAt { get; set; }
	
	public required FlightStatus Status { get; set; }
	
	[MaxLength(500)]
	public string? Note { get; set; }
	
	public required DateTime AcceptedAt { get; set; }

	public required DateTime CreatedAt { get; set; }
	
	public required DateTime UpdatedAt { get; set; }
	
	public User User { get; set; }
	
	public Plane Plane { get; set; }
}