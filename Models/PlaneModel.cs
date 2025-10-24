using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.Models;

public class PlaneModel
{
	public long Id { get; set; }
	
	public required string Model { get; set; }
	
	public required int BoardNumber { get; set; }
	
	public required DateTime CreatedAt { get; set; }
	
	public required DateTime UpdatedAt { get; set; }
	
	public required string EngineType { get; set; }
}