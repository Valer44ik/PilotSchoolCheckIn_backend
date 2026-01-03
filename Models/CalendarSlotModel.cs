namespace PilotSchoolCheckIn.Models;

public class CalendarSlotModel
{
	public long Id { get; set; }
	public DateTime? Start { get; set; }
	public DateTime? End { get; set; }
	public string? Description { get; set; }
	public string? InstructorAbbreviation { get; set; }
	public string? ClientSurname { get; set; }
}