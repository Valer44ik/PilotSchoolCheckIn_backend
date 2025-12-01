using System.ComponentModel.DataAnnotations;
using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.Models;

public class FlightReservationModel
{
	public long Id { get; set; }
	
	public required long ClientId { get; set; }
	
	public required long InstructorId { get; set; }
	
	public required long PlaneId { get; set; }
	
	public required DateTime StartsAt { get; set; }
	
	public required DateTime EndsAt { get; set; }
	
	[MaxLength(500)]
	public string? Note { get; set; }
}