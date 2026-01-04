namespace PilotSchoolCheckIn.Models;

public class RegistrationModel
{
	public long Id { get; set; }
	public required string Name { get; set; }
	public required string Surname { get; set; }
	public string? Abbreviation { get; set; }
	public required string PhoneNumber { get; set; }
	public required string Password { get; set; }
	public required string Email { get; set; }
	public string? Nationality { get; set; }
	public string? Gender { get; set; }
	public string? Language { get; set; }
	public string? BirthYear { get; set; }
}